using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Shine.Utility
{
    /// <summary>
    /// 文件处理程序
    /// </summary>
    public static class FileUntility
    {
        /// <summary>
        /// Determine whether the path exists
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public static bool DetermineWhetherPathExists(string _path)
        {
            bool result = false;

            if (File.Exists(_path))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Determine Whether Path Exists
        /// If the file does not exist, create it
        /// </summary>
        /// <param name="_path"></param>
        public static void DeterminePathExists(string _path)
        {
            string folderPath = _path.Substring(0, _path.LastIndexOf('/') + 1);

            Debug.Log(folderPath);

            DirectoryInfo directory = new DirectoryInfo(folderPath);

            if (!directory.Exists)
            {
                directory.Create();
            }

            if (File.Exists(_path))
            {
                return;
            }

            File.Create(_path);
        }
    }
}