using System;

namespace RunningTSQLwithGOscripts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Func<string, string> func = ResourceReader.GetResourceText;

            string scriptText = func("RunningTSQLwithGOscripts.Scripts.createddb.sql");
            SqlRuner.RunBatch(scriptText, true);

            scriptText = func("RunningTSQLwithGOscripts.Scripts.upgrade1.sql");
            SqlRuner.RunBatch(scriptText, true);

            scriptText = func("RunningTSQLwithGOscripts.Scripts.dropdb.sql");
            SqlRuner.RunBatch(scriptText, true);
        }
    }
}