using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Fox.Assets
{
    public abstract class AssetsLoader<T>
    {
        private class LoaderCallback : IRelease
        {
            private string path;
            private Action<T> callback;
            private AssetsLoader<T> loader;

            internal LoaderCallback(AssetsLoader<T> loader)
            {
                this.loader = loader;
            }

            internal void SetLoader(in string path, in Action<T> callback)
            {
                this.path = path;
                this.callback = callback;
            }

            public void Release()
            {
                path = null;
                callback = null;
                loader = null;
            }

            internal void Completed(AsyncOperationHandle<T> handle)
            {
                callback(handle.Result);
                handle.Completed -= Completed;
                loader.RecyclingCallback(this);
            }
        }

        protected virtual uint callBackPoolSize => 10;

        private LoaderCallback[] callBackPool;

        private int poolPointer;

        private Dictionary<string, AsyncOperationHandle<T>> handles;

        public AssetsLoader()
        {
            callBackPool = new LoaderCallback[callBackPoolSize];
            poolPointer = (int)callBackPoolSize;
        }

        private LoaderCallback GetCallback()
        {
            LoaderCallback call;
            if (poolPointer > -1)
            {
                call = callBackPool[poolPointer--];
            }
            else
            {
                call = new LoaderCallback(this);
            }
            return call;
        }

        private void RecyclingCallback(LoaderCallback callBack)
        {
            if (poolPointer == callBackPoolSize)
            {
                callBack.Release();
                return;
            }
            callBackPool[++poolPointer] = callBack;
        }

        protected void LoadAssets(in string path, in Action<T> callback)
        {
            var handle = Addressables.LoadAssetAsync<T>(path);
            LoaderCallback call = GetCallback();
            call.SetLoader(in path, in callback);
            handle.Completed += call.Completed;
        }

        protected void ReleaseAssets(in string path)
        {
            if (handles.TryGetValue(path,out var handle))
            {
                Addressables.Release<T>(handle);
            }
        }
    }
}