using System;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Settings = RunningTSQLwithGOscripts.Properties.Settings;

namespace RunningTSQLwithGOscripts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Func<string, string> func = ResourceReader.GetResourceText;

            string scriptText = func("RunningTSQLwithGOscripts.Scripts.createddb.sql");
            RunScript(scriptText);

            scriptText = func("RunningTSQLwithGOscripts.Scripts.upgrade1.sql");
            RunScript(scriptText);

            scriptText = func("RunningTSQLwithGOscripts.Scripts.dropdb.sql");
            RunScript(scriptText);
        }

        private static void RunScript(string scriptText)
        {
            SqlConnection sqlConnection = new SqlConnection(Settings.Default.TestDb);
            ServerConnection svrConnection = new ServerConnection(sqlConnection);
            Server server = new Server(svrConnection);
            server.ConnectionContext.ExecuteNonQuery(scriptText);
        }
    }
}