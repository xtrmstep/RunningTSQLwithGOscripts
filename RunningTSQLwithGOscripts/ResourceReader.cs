using System;
using System.IO;
using System.Reflection;

namespace RunningTSQLwithGOscripts
{
    internal class ResourceReader
    {
        public static string ReadText(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                if (stream != null)
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
            return null;
        }

        public static string GetResourceText(string key)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string result = null;
            using (Stream s = assembly.GetManifestResourceStream(key))
            {
                if (s == null)
                    throw new ArgumentException("Key is not found in resources.", "key");

                using (StreamReader sr = new StreamReader(s))
                    result = sr.ReadToEnd();
            }
            return result;
        }
    }
}