



using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoDotNetEFProject.DAL
{
    public class TableTicket : ICurrentCrud<Ticket>
    {
       
        private const string TABLE = TableNames.TABLE_TICKET;
        private const string ID = TableTicketColumn.ID;
        private const string TICKETNUMBER = TableTicketColumn.TICKETNUMBER;
        private const string PASSENGERID = TableTicketColumn.PASSENGERID;

        public readonly SqlServiceProvider<Ticket> sqlServiceProviders = new SqlServiceProvider<Ticket>();

        public TableTicket()
        {
            sqlServiceProviders = new SqlServiceProvider<Ticket>();
        }
        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await sqlServiceProviders.GetAllAsync(tableName: TABLE);
        }

        public async Task<Ticket> GetByIdAsync(int Id)
        {
            return await sqlServiceProviders.FindByIdAsync(tableName: TABLE, columnName: ID, Id);
        }

        public async Task InsertAsync(Ticket obj)
        {
            var sql = $"INSERT INTO {TABLE}({TICKETNUMBER}, {PASSENGERID}) VALUES({obj.TickNumbers}, {obj.passangerId})";
            await sqlServiceProviders.UpdateAndInsertAsync(sql);
        }

        public async Task UpdateAsync(Ticket obj)
        {
            var sql = $"UPDATE {TABLE} SET{TICKETNUMBER}= {obj.TickNumbers}, {PASSENGERID} = {obj.passangerId}  WHERE Ticket_Id = {obj.Ticket_Id}";
            await sqlServiceProviders.UpdateAndInsertAsync(sql);
        }
    }
}
