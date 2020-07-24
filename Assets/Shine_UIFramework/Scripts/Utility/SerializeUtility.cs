using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Shine.Utility
{
    /// <summary>
    /// Serialize and Deserialize method
    /// </summary>
    public static class SerializeUtility
    {

        /// <summary>
        /// Serialize Data
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public static byte[] SerializeData(object _obj)
        {
            if (string.IsNullOrEmpty(_obj.ToString()))
            {
                return null;
            }

            byte[] result = null;

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _obj);

                result = stream.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Serialize Data
        /// </summary>
        /// <param name="_filePath"></param>
        /// <param name="_obj"></param>
        public static void SerializeData(string _filePath,object _obj)
        {
            FileUntility.DeterminePathExists(_filePath);
            
            using (FileStream stream = new FileStream(_filePath, FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _obj);
            }
        }

        /// <summary>
        /// Deserialize Data
        /// </summary>
        /// <param name="_byte"></param>
        /// <returns></returns>
        public static object DeserializeData(byte[] _bytes)
        {
            if (_bytes.Length <= 0)
            {
                return null;
            }

            object result = null;

            using (MemoryStream stream = new MemoryStream(_bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                result = formatter.Deserialize(stream);
            }

            return result;
        }

        /// <summary>
        /// Deserialize Data
        /// </summary>
        /// <param name="_path">The path of the deserialized file</param>
        /// <returns></returns>
        public static object DeserializeData(string _path)
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }

            bool isExist = FileUntility.DetermineWhetherPathExists(_path);

            if (!isExist)
            {
                return null;
            }

            object result = null;

            using (FileStream stream = new FileStream(_path,FileMode.Open,FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                result = formatter.Deserialize(stream);
            }

            return result;
        }
    }
}