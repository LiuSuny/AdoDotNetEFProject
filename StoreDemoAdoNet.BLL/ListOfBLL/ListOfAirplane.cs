

using AdoDotNetEFProject.DAL;

namespace AdoDotNetEFProject.BLL
{
    public class ListOfAirplane
    {
        private readonly ICurrentCrud<DAL.Airplane> _source;
        public List<Airplane> users { get; }

        public ListOfAirplane()
        {
            _source = new TableAirplane();
        }

        public async IAsyncEnumerable<Airplane> GetAllAsync()
        {
            var result = await _source.GetAllAsync();
            foreach(var airplane in result)
            {
               yield return BLMappers.MapAirplaneDALToAirplaneBLL(airplane);
            }
           
        }
        public async Task<Airplane> GetByIdAsync(int id)
        {
            var result = await _source.GetByIdAsync(id);
            return BLMappers.MapAirplaneDALToAirplaneBLL(result);

        }

        public async Task InsertAsync(Airplane airplane)
        {
            await _source.InsertAsync(BLMappers.MapAirplaneBLLToAirplaneDAL(airplane));

        }

        public async Task UpdateAsync(Airplane airplane)
        {
            await _source.UpdateAsync(BLMappers.MapAirplaneBLLToAirplaneDAL(airplane));
        }
    }
}
