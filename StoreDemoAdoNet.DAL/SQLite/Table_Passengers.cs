



namespace AdoDotNetEFProject.DAL
{
    public class Table_Passengers : ICurrentCrud<Passengers>
    {
  
        private const string TABLE = TableNames.TABLE_PASSENGERS;
        private const string ID = TablePassengersColumn.ID;
        private const string FIRSTNAME = TablePassengersColumn.FIRSTNAME;
        private const string LASTNAME = TablePassengersColumn.LASTNAME;
        private const string AGE = TablePassengersColumn.AGE;
        private const string TAKEOFFDESTINATION = TablePassengersColumn.TAKEOFFDISTINATION;
        private const string ARRIVALOFFDESTINATION = TablePassengersColumn.ARRIVALOFFDISTINATION;
        private const string AIRPLANEID = TablePassengersColumn.AIRPLANEID;

        public readonly SqlServiceProvider<Passengers> sqlServiceProviders = new SqlServiceProvider<Passengers>();

        public Table_Passengers()
        {
            sqlServiceProviders = new SqlServiceProvider<Passengers>();
        }

        public async Task<IEnumerable<Passengers>> GetAllAsync()
        {
            return await sqlServiceProviders.GetAllAsync(tableName: TABLE);
        }

        public async Task<Passengers> GetByIdAsync(int Id)
        {
            return await sqlServiceProviders.FindByIdAsync(tableName: TABLE, columnName: ID, Id);
        }

        public async Task InsertAsync(Passengers obj)
        {
            var sql = $"INSERT INTO {TABLE}({FIRSTNAME}, {LASTNAME}, {AGE}, {TAKEOFFDESTINATION}, {ARRIVALOFFDESTINATION}, {AIRPLANEID}) VALUES({obj.First_Name}, {obj.Last_Name}, {obj.Age}, {obj.passeengerTakeOffTime}, {obj.passeengerArrivalTime}, {obj.airplaneId})";
            await sqlServiceProviders.UpdateAndInsertAsync(sql);
        }

        public async Task UpdateAsync(Passengers obj)
        {
            var sql = $"UPDATE {TABLE} SET{FIRSTNAME} = {obj.First_Name}, {LASTNAME} = {obj.Last_Name}, {AGE} = {obj.Age}, {TAKEOFFDESTINATION} = {obj.passeengerTakeOffTime}, {ARRIVALOFFDESTINATION} = {obj.passeengerArrivalTime}, {AIRPLANEID} = {obj.airplaneId}) WHERE ID = {obj.airplaneId}";
            await sqlServiceProviders.UpdateAndInsertAsync(sql);
        }

    }
}
