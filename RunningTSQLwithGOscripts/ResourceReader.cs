using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunningTSQLwithGOscripts
{
    class ResourceReader
    {
        public static string ReadText(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
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
            var assembly = Assembly.GetExecutingAssembly();

            string result = null;
            using (var s = assembly.GetManifestResourceStream(key))
            {
                if (s == null)
                    throw new ArgumentException("Key is not found in resources.", "key");

                using (var sr = new StreamReader(s))
                    result = sr.ReadToEnd();
            }
            return result;
        }
    }
}
