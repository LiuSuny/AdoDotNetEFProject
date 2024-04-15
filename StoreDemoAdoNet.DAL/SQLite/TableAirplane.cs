


namespace AdoDotNetEFProject.DAL
{
    public class TableAirplane : ICurrentCrud<Airplane>
    {
       
        private const string TABLE = TableNames.TABLE_AIRPLANE;
        private const string ID = TableAirplaneColumn.ID;
        private const string PLANENUMBERS = TableAirplaneColumn.PLANENUMBERS;
        private const string COLOR = TableAirplaneColumn.COLOR;
        private const string PLANEPRODUCTIONYEAR = TableAirplaneColumn.PRODUCTIONYEAR;
        private const string NUMBEROFPASSENGER = TableAirplaneColumn.NUMBEROFPASSENGERS;
        
      
        public readonly SqlServiceProvider<Airplane> sqlServiceProviders;

        public TableAirplane()
        {
            sqlServiceProviders = new SqlServiceProvider<Airplane>();
        }

        public async Task<IEnumerable<Airplane>> GetAllAsync()
        {
            return await sqlServiceProviders.GetAllAsync(tableName: TABLE);
        }

        public async Task<Airplane> GetByIdAsync(int Id)
        {
            return await sqlServiceProviders.FindByIdAsync(tableName: TABLE, columnName: ID, key: Id);
        }

        public async Task InsertAsync(Airplane obj)
        {
            var sql = $"INSERT INTO {TABLE} ({PLANENUMBERS}, {COLOR}, {PLANEPRODUCTIONYEAR}, {NUMBEROFPASSENGER}) VALUES('{obj.PlaneNumbers}, {obj.Colors}, {obj.planeProductionYear}, {obj.NumberOfPassanges}')";
            await sqlServiceProviders.UpdateAndInsertAsync(sql);
        }

        public async Task UpdateAsync(Airplane obj)
        {
            //TO RETURN:
            var sql = $"UPDATE {TABLE} SET{PLANENUMBERS} = {obj.PlaneNumbers}, {COLOR} = {obj.Colors}, {PLANEPRODUCTIONYEAR} = {obj.planeProductionYear}, {NUMBEROFPASSENGER} = {obj.NumberOfPassanges} WHERE Id = {obj.airplaneId}";
            await sqlServiceProviders.UpdateAndInsertAsync(sql);
        }
    }
}
