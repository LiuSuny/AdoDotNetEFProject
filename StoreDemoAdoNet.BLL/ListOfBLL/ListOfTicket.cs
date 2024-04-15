

using AdoDotNetEFProject.DAL;

namespace AdoDotNetEFProject.BLL
{
    public class ListOfTicket
    {
        private readonly ICurrentCrud<DAL.Ticket> _source;
        private List<Ticket> sales { get; }

        public ListOfTicket()
        {
            _source = new TableTicket();
        }

        public async IAsyncEnumerable<Ticket> GetAllAsync()
        {
            
            var tablePassengers = new Table_Passengers();          
            var passenger = await tablePassengers.GetAllAsync();

            var result = await _source.GetAllAsync();
            foreach(var ticket in result)
            {
               yield return BLMappers.MapTicketDALToTicketBLL(ticket, passenger);
            }
           
        }
        public async Task<Ticket> GetByIdAsync(int id)
        {          
            var tablePassengers = new Table_Passengers();            
            var passenger = await tablePassengers.GetAllAsync();

           
            //var users = await tableAirplane.GetByIdAsync(passenger_id);
            //var passengers = await tablePassengers.GetByIdAsync(passenger_id);

            var result = await _source.GetByIdAsync(id);
            return BLMappers.MapTicketDALToTicketBLL(result, passenger);

        }

        public async Task InsertAsync(Ticket ticket)
        {
            
            await _source.InsertAsync(BLMappers.MapTicketBLLToTicketDAL(ticket));

        }

        public async Task UpdateAsync(Ticket ticket)
        {
            await _source.UpdateAsync(BLMappers.MapTicketBLLToTicketDAL(ticket));
        }
    }
}
