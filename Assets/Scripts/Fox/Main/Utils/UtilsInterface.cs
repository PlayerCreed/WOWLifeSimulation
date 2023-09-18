namespace Fox
{
    public interface IRelease
    {
        public void Release();
    }

    public interface IUpdate
    {
        public void Update();
    }

    public interface ILateUpdate
    {
        public void LateUpdate();
    }

    public interface IFixedUpdate
    {
        public void FixedUpdate();
    }
}