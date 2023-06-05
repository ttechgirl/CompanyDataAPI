using DbUp;
using DbUp.Engine.Output;
using DbUp.Helpers;

namespace CompanyDataAPI
{
    public static partial class Startup
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            //app.UseRouting();
            
            TableMigrationScript(app);
            StoredProcedureMigrationScript(app);
            return app;
        }

        /// <summary>
        /// Sql migration for table Schema
        /// </summary>
        public static void TableMigrationScript(this WebApplication app)
        {
            string dbConnStr = app.Configuration.GetConnectionString("ConnectingToDB");
            EnsureDatabase.For.SqlDatabase(dbConnStr);

            var upgrader = DeployChanges.To.SqlDatabase(dbConnStr)
            .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sql", "Tables"))
            .WithTransactionPerScript()
            .JournalToSqlTable("dbo", "TableMigration")
             .LogToConsole()
            .LogTo(new SerilogDbUpLog(app.Logger))
            .WithVariablesDisabled()
            .Build();

            upgrader.PerformUpgrade();
        }
        /// <summary>
        /// Sql migration for stored procedure
        /// </summary>
        public static void StoredProcedureMigrationScript(this WebApplication app)
        {
            string dbConnStr = app.Configuration.GetConnectionString("ConnectingToDB");
            EnsureDatabase.For.SqlDatabase(dbConnStr);

            var upgrader = DeployChanges.To.SqlDatabase(dbConnStr)
            .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sql", "Sprocs"))
            .WithTransactionPerScript()
            .JournalTo(new NullJournal())
            .JournalToSqlTable("dbo", "SprocsMigration")
            .LogTo(new SerilogDbUpLog(app.Logger))
            .LogToConsole()
            .Build();

            upgrader.PerformUpgrade();
        }

    }

    //Serilog
    public class SerilogDbUpLog : IUpgradeLog
    {
        private readonly ILogger _logger;

        public SerilogDbUpLog(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteError(string format, params object[] args)
        {
            _logger.LogError(format, args);
        }

        public void WriteInformation(string format, params object[] args)
        {
            _logger.LogInformation(format, args);
        }

        public void WriteWarning(string format, params object[] args)
        {
            _logger.LogWarning(format, args);
        }
    }
}
