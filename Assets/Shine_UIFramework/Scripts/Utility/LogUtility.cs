using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shine.Utility;

namespace Shine.Utility
{
    /// <summary>
    /// 日志应用
    /// </summary>
    public sealed class LogUtility
    {
        public LogUtility() { }

        /// <summary>
        /// 是否启用日志打印(默认设定为打开)
        /// </summary>
        public static bool EnableLog = true;

        /// <summary>
        /// 是否启用屏幕输出(默认设定为不输出)
        /// </summary>
        public static bool EnableOutput = false;

        /// <summary>
        /// 是否启用文件保存(默认设定为不启用)
        /// </summary>
        public static bool EnableSaveFile = false;

        /// <summary>
        /// 文件路径
        /// </summary>
        private static string filePath;

        /// <summary>
        /// 自定义文件夹
        /// </summary>
        private static string customizePath = "/Data/";

        /// <summary>
        /// 文件名称
        /// </summary>
        private static string fileName = "Log.txt";

        /// <summary>
        /// 输出日志的集合
        /// </summary>
        private static List<string> lines = new List<string>();

        /// <summary>
        /// Log a message to the Unity Console.
        /// </summary>
        /// <param name="message"></param>
        public static void Log(object message)
        {
            if (EnableLog)
            {
                Debug.Log(message);
            }
        }

        /// <summary>
        /// Log a message to the Unity Console.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public static void Log(object message,Object context)
        {
            if (EnableLog)
            {
                Debug.Log(message, context);
            }
        }

        /// <summary>
        /// Logs a formatted message to the Unity Console.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Log(string format,params object[] args)
        {
            if (EnableLog)
            {
                Debug.LogFormat(format, args);
            }
        }

        /// <summary>
        /// Logs a formatted message to the Unity Console.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Log(Object context, string format, params object[] args)
        {
            if (EnableLog)
            {
                Debug.LogFormat(context, format, args);
            }
        }

        /// <summary>
        /// A variant of Debug.Log that logs an error message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(object message)
        {
            if (EnableLog)
            {
                Debug.LogError(message);
            }
        }

        /// <summary>
        /// A variant of Debug.Log that logs an error message to the console.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public static void LogError(object message,Object context)
        {
            if (EnableLog)
            {
                Debug.LogError(message, context);
            }
        }

        /// <summary>
        /// A variant of Debug.Log that logs a warning message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(object message)
        {
            if (EnableLog)
            {
                Debug.LogWarning(message);
            }
        }

        /// <summary>
        /// A variant of Debug.Log that logs a warning message to the console.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public static void LogWarning(object message,Object context)
        {
            if (EnableLog)
            {
                Debug.LogWarning(message, context);
            }
        }

        /// <summary>
        /// 初始化文件路径，便于后续用于保存文件
        /// </summary>
        /// <param name="fileName">带后缀的文件名</param>
        public static void InitFilePath(string _fileName = null)
        {
            if (EnableSaveFile)
            {
                if (!string.IsNullOrEmpty(_fileName))
                {
                    fileName = _fileName;
                }

                filePath =
                #if UNITY_EDITOR
                    Application.persistentDataPath + customizePath + fileName;
                #elif UNITY_IPHONE
                    "file://" + Application.persistentDataPath + customizePath + fileName;
                #elif UNITY_ANDROID
                    "jar:file://" + Application.persistentDataPath + customizePath + fileName;
                #endif

                FileUntility.DeterminePathExists(filePath);
            }
        }


    }
}