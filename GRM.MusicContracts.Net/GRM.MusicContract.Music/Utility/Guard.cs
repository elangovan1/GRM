using System;
using System.Collections.Generic;
using System.IO;

namespace GRM.MusicContract.Music.Utility
{
    public class Guard
    {
        public static void ArgumentIsNotNullOrEmpty(object value, string argument)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                throw new ArgumentNullException(argument);
        }

        public static void KeyNotFoundException(object value, string argument)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                throw new KeyNotFoundException(argument);
        }

        public static void IfFileDoesNotExist(object value, string argument)
        {
            if (!File.Exists(value.ToString()))
                throw new FileNotFoundException(argument);
        }

        public static void ArgumentIsNotNull(object value, string argument)
        {
            if (value == null)
                throw new ArgumentNullException(argument);
        }
    }
}