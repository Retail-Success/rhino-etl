namespace Rhino.Etl.Core.ConventionOperations
{
    using System.Configuration;
    using System.Data;
    using Rhino.Etl.Core.Infrastructure;
    using Rhino.Etl.Core.Operations;

    /// <summary>
    /// A convention based version of <see cref="OutputCommandOperation"/>. Will
    /// figure out as many things as it can on its own.
    /// </summary>
    public class ConventionOutputCommandOperation : OutputCommandOperation
    {
        private string command;


        /// <summary>
        /// Initializes a new instance of the <see cref="ConventionOutputCommandOperation"/> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        public ConventionOutputCommandOperation(string connectionStringName)
            : this(Use.ConnectionString(connectionStringName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConventionOutputCommandOperation"/> class.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string settings to use.</param>
        public ConventionOutputCommandOperation(ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings)
        {
        }

        /// <summary>
        /// Gets or sets the command to execute against the database
        /// </summary>
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        /// <summary>
        /// Prepares the row by executing custom logic before passing on to the <see cref="PrepareCommand"/>
        /// for further process.
        /// </summary>
        /// <param name="row">The row.</param>
        protected virtual void PrepareRow(Row row)
        {
        }

        /// <summary>
        /// Prepares the command for execution, set command text, parameters, etc
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="row">The row.</param>
        protected override void PrepareCommand(IDbCommand cmd, Row row)
        {
            PrepareRow(row);
            cmd.CommandText = Command;
            CopyRowValuesToCommandParameters(currentCommand, row);
        }

    }
}