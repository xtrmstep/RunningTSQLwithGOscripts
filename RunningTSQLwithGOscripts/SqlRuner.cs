using System.Data.SqlClient;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Settings = RunningTSQLwithGOscripts.Properties.Settings;

namespace RunningTSQLwithGOscripts
{
    internal class SqlRuner
    {
        public static void RunScript(string scriptText)
        {
            SqlConnection sqlConnection = new SqlConnection(Settings.Default.TestDb);
            ServerConnection svrConnection = new ServerConnection(sqlConnection);
            Server server = new Server(svrConnection);
            server.ConnectionContext.ExecuteNonQuery(scriptText);
        }

        public static void RunBatch(string scriptText, bool cmdMode = false)
        {
            if (cmdMode)
                RunInCmd(scriptText);
            else
                RunPatched(scriptText);
        }

        private static void RunPatched(string scriptText)
        {
            SqlConnection sqlConnection = new SqlConnection(Settings.Default.TestDb);
            ServerConnection svrConnection = new ServerConnection(sqlConnection);
            Server server = new Server(svrConnection);
            var batch = new StringBuilder(scriptText);
            batch.Replace("'", "''");
            batch.Replace(@"
GO", string.Empty);
            batch.Replace(@"
go", string.Empty);
            batch.Insert(0, "exec('").Append("')");
            string sqlCommand = batch.ToString();
            server.ConnectionContext.ExecuteNonQuery(sqlCommand);
        }

        private static void RunInCmd(string scriptText)
        {
            var batch = new StringBuilder(scriptText);
            batch.Insert(0, "sqlcmd -S .\\SQLEXPRESS -d TestDb -Q \"").Append("\"");
            string userName = batch.ToString();
            System.Diagnostics.Process.Start("CMD.exe", userName);
        }
    }
}