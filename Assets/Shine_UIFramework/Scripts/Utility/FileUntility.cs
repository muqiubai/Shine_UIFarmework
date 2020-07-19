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
        /// <param name="_folderPath"></param>
        /// <param name="_fileName"></param>
        public static void DetermineWhetherPathExists(string _folderPath,string _fileName)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            string filePath = _folderPath + @"\" + _fileName;

            if (File.Exists(filePath))
            {
                return;
            }

            File.Create(filePath);
        }
    }
}