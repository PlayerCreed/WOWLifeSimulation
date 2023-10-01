using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Fox
{

    public static class StringUtil
    {
        static StringBuilder formatBuilder = new StringBuilder(50);//字符串格式化的时候用
        /// <summary>
        /// 正则表达式
        /// </summary>
        private static Regex REGEX = new Regex(@"\{[-+]?[0-9]+\.?[0-9]*\}", RegexOptions.IgnoreCase);


        public static string Append(params object[] args)
        {
            formatBuilder.Clear();
            for (int i = 0; i < args.Length; i++)
            {
                formatBuilder.Append(args[i]);
            }
            return formatBuilder.ToString();
        }
        public static string Append(params char[] args)
        {
            formatBuilder.Clear();
            formatBuilder.Append(args);
            return formatBuilder.ToString();
        }
        public static string AppendFormat(string format, params string[] args)
        {
            formatBuilder.Clear();
            return formatBuilder.AppendFormat(format, args).ToString();
        }
        /// <summary>
        /// 替换掉字符串里的特殊字符
        /// </summary>
        public static string ReplaceSpecialChar(this string str)
        {
            return str.Replace("\\n", "\n").Replace("\\r", "'\r").Replace("\\t", "\t");
        }

        /// <summary>
        /// 字符串转换为BOOL
        /// </summary>
        public static bool ToBool(this string str)
        {
            int value = (int)Convert.ChangeType(str, typeof(int));
            return value > 0;
        }

        /// <summary>
        /// 字符串转换为Int
        /// </summary>
        public static byte ToByte(this string str)
        {
            byte result = 0;
            byte.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为Int
        /// </summary>
        public static int ToInt(this string str)
        {
            int result = 0;
            int.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为Uint
        /// </summary>
        public static uint ToUint(this string str)
        {
            uint result = 0;
            uint.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为Float
        /// </summary>
        public static float ToFloat(this string str)
        {
            float result = 0;
            float.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为Long
        /// </summary>
        public static long ToLong(this string str)
        {
            long result = 0;
            long.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为数值
        /// </summary>
        public static T StringToValue<T>(this string str)
        {
            return (T)Convert.ChangeType(str, typeof(T));
        }

        /// <summary>
        /// 字符串转换为数值列表
        /// </summary>
        /// <param name="separator">分隔符</param>
        public static List<T> ToValueList<T>(this string str, params char[] separator)
        {
            List<T> result = new List<T>();
            if (!String.IsNullOrEmpty(str))
            {
                string[] splits = str.Split(separator);
                foreach (string split in splits)
                {
                    if (!String.IsNullOrEmpty(split))
                    {
                        result.Add((T)Convert.ChangeType(split, typeof(T)));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 字符串转为字符串列表
        /// </summary>
        public static List<string> ToStringList(this string str, params char[] separator)
        {
            List<string> result = new List<string>();
            if (!String.IsNullOrEmpty(str))
            {
                string[] splits = str.Split(separator);
                foreach (string split in splits)
                {
                    if (!String.IsNullOrEmpty(split))
                    {
                        result.Add(split);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 转换为枚举
        /// 枚举索引转换为枚举类型
        /// </summary>
        public static T IndexToEnum<T>(this string index) where T : IConvertible
        {
            int enumIndex = (int)Convert.ChangeType(index, typeof(int));
            return IndexToEnum<T>(enumIndex);
        }

        /// <summary>
        /// 转换为枚举
        /// 枚举索引转换为枚举类型
        /// </summary>
        public static T IndexToEnum<T>(int index) where T : IConvertible
        {
            if (Enum.IsDefined(typeof(T), index) == false)
            {
                throw new ArgumentException($"Enum {typeof(T)} is not defined index {index}");
            }
            return (T)Enum.ToObject(typeof(T), index);
        }

        /// <summary>
        /// 转换为枚举
        /// 枚举名称转换为枚举类型
        /// </summary>
        public static T NameToEnum<T>(this string name)
        {
            if (Enum.IsDefined(typeof(T), name) == false)
            {
                throw new ArgumentException($"Enum {typeof(T)} is not defined name {name}");
            }
            return (T)Enum.Parse(typeof(T), name);
        }

        /// <summary>
        /// 字符串转换为参数列表
        /// </summary>
        public static List<float> ToParams(this string str)
        {
            List<float> result = new List<float>();
            MatchCollection matches = REGEX.Matches(str);
            for (int i = 0; i < matches.Count; i++)
            {
                string value = matches[i].Value.Trim('{', '}');
                result.Add(value.ToFloat());
            }
            return result;
        }

        /// <summary>
        /// 字符串转换为向量
        /// </summary>
        public static Vector3 ToVector3(this string str, char separator)
        {
            List<float> values = ToValueList<float>(str, separator);
            return new Vector3(values[0], values[1], values[2]);
        }


        /// <summary>
        /// 按字符个数截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count">字符个数</param>
        /// <param name="etc">截取字符串后添加的后缀</param>
        /// <returns></returns>
        public static string GetLimitStr(this string str, int count, string etc = "")
        {
            int maxIndex = -1;//截止到最大索引
            int t = 0;
            for (int index = 0; index < str.Length; index++)
            {
                if (str[index] >= 0x4E00 && str[index] <= 0x9FA5)//是否汉字
                {
                    t += 2;
                }
                else
                {
                    t += 1;
                }
                if (t >= count)
                {
                    maxIndex = index;
                    break;
                }
            }
            if (maxIndex != -1)
            {//字符串需要截取
                if (string.IsNullOrEmpty(etc))
                {
                    return str.Substring(0, maxIndex + 1);
                }
                return str.Substring(0, maxIndex + 1) + etc;
            }
            return str;
        }

    }
}