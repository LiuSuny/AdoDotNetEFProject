

using Dapper;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace AdoDotNetEFProject.DAL
{
    /// <summary>
    /// Service class that implement all our connection services
    /// </summary>
    /// <typeparam name="T">Generic values</typeparam>
    public class SqlServiceProvider<T>
    {
        #region Private Property
        private readonly SqliteConnection _db;
        #endregion

        /// <summary>
        /// Ctor with default and non default args
        /// </summary>
        /// <param name="configPath">Connect to config.json which take in our database</param>
        public SqlServiceProvider(string configPath = "Config.json")
        {
            //Connecting to database sqlite
            var connectionString =  DataBaseConfig.GetFromDataBaseConfig(configPath)?.ToString();

            //if (connectionString is null) return;
            
            //runing a check to see if our connectionstring is null or empty throw customize exception
            if(string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(message: $"Problem reading config{configPath}");
            }

            //However if our check is not null then connect
            _db = new SqliteConnection(connectionString);

            //this help allign our tables regarding how we tableout on c#
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        /// <summary>
        /// Universial method that return all our data from table
        /// </summary>
        /// <param name="TableName">Value</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync(string tableName)
          {
            //First we must open our database
             await _db.OpenAsync();

            //Next we create sql query
            var sql = $"SELECT * FROM {tableName}";

            //Request a details of tablename using library called Dapper query
            //var result = await _db.QueryAsync<T>(sql); or
            IEnumerable<T> result = await _db.QueryAsync<T>(sql);

            //Close our database
            await _db.CloseAsync();

            //Return our dapper queryAsync
            //NOTE: that since we started our method
            //using async Task, reason why we continue Adding Async at the end of every Operation e.g QueryAsync or OpenAsync etc
            return result;
          }

        public async Task<T> FindByIdAsync( string tableName, string columnName, int key)
        {
            //First we must open our database
            await _db.OpenAsync();

            //Next we create sql query
            var sql = $"SELECT * FROM {tableName} WHERE {columnName} = {key}";

            //Request a details of tablename using library called Dapper query
            //var result = await _db.QueryAsync<T>(sql);
            T result = await _db.QuerySingleAsync<T>(sql);

            //Close our database
            await _db.CloseAsync();

            //Return our dapper queryAsync
            //NOTE: that since we started our method
            //using async Task, reason why we continue Adding Async at the end of every Operation e.g QueryAsync or OpenAsync etc
            return result;
        }

        public async Task UpdateAndInsertAsync(string sql)
        {
            //First we must open our database
            await _db.OpenAsync();
            //Request a details of table executeasync using library called Dapper query
            await _db.ExecuteAsync(sql);

            //Close our database
            await _db.CloseAsync();
        }
    }
}
