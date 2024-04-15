

using AdoDotNetEFProject.DAL;

namespace AdoDotNetEFProject.BLL
{
    public class ListOfPassengers
    {
        private readonly ICurrentCrud<DAL.Passengers> _source;
        private List<Passengers> passengers { get; }

        public ListOfPassengers()
        {
            _source = new Table_Passengers();
        }

        public async IAsyncEnumerable<Passengers> GetAllAsync()
        {
            var tableAirplane = new TableAirplane();
            var airplane = await tableAirplane.GetAllAsync();

            var result = await _source.GetAllAsync();
            foreach(var passenger in result)
            {
               yield return BLMappers.MapPassengerDALToPassengerBLL(passenger, airplane);
            }
           
        }
        public async Task<Passengers> GetByIdAsync(int id)
        {
            var tableAirplane = new TableAirplane();
            var airplane = await tableAirplane.GetAllAsync();

            var result = await _source.GetByIdAsync(id);
            return BLMappers.MapPassengerDALToPassengerBLL(result, airplane);

        }

        public async Task InsertAsync(Passengers passenger)
        {
            await _source.InsertAsync(BLMappers.MapPassengerBLLToPassengerDAL(passenger));

        }

        public async Task UpdateAsync(Passengers passenger)
        {
            await _source.UpdateAsync(BLMappers.MapPassengerBLLToPassengerDAL(passenger));
        }
    }
}
