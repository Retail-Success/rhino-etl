using System.Configuration;

namespace Rhino.Etl.Tests.Integration
{
    using System.Data;
    using Rhino.Etl.Core;
    using Rhino.Etl.Core.Operations;

    public class WritePeople : OutputCommandOperation
    {
        public WritePeople(string connectionStringName) 
            : base(connectionStringName)
        {
        }

        public WritePeople(ConnectionStringSettings connectionStringSettings) : base(connectionStringSettings)
        {
        }

        protected override void PrepareCommand(IDbCommand cmd, Row row)
        {
            cmd.CommandText =
                @"INSERT INTO People (UserId, FirstName, LastName, Email) VALUES (@UserId, @FirstName, @LastName, @Email)";
            AddParameter("UserId", row["Id"]);
            AddParameter("FirstName", row["FirstName"]);
            AddParameter("LastName", row["LastName"]);
            AddParameter("Email", row["Email"]);
        }
    }
}