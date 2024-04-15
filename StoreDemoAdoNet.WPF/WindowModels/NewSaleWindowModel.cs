

using AdoDotNetEFProject.BLL;
using AdoDotNetEFProject.DAL;
using System.Collections.ObjectModel;

namespace AdoDotNetEFProject.WPF.WindowModels
{
    public class NewSaleWindowModel : BaseNotify
    {
        private readonly Context _context;

        public ObservableCollection<Airplane> airplane { get; set; }
        public ObservableCollection<Passengers> passenger { get; set; }

   
        private Airplane? _selectedAirplane;
        public Airplane? SelectedAirplane
        {
            get => _selectedAirplane;
            set => SetField(ref _selectedAirplane, value);
        }

        private Passengers? _selectedPassenger;
        public Passengers? SelectedPassenger
        {
            get => _selectedPassenger;
            set => SetField(ref _selectedPassenger, value);
        }

        public LambdaCommand CommandSave { get; set; }
        public LambdaCommand CommandClear { get; set; }

        public NewSaleWindowModel()
        {
            _context = new Context();

            ListOfAirplane sourceAirplane = _context.airplane;
            IEnumerable<Airplane> airplanes = sourceAirplane
                .GetAllAsync()
                .ToBlockingEnumerable()
                .Select(UIMappers.MapBLLAirplaneToUIAirplane);
            airplanes= new ObservableCollection<Airplane>(airplanes);

            var passenger = _context
                .passengers
                .GetAllAsync()
                .ToBlockingEnumerable()
                .Select(UIMappers.MapBLLPassengerToUIPassenger);
            passenger = new ObservableCollection<Passengers>(passenger);

            CommandSave = new LambdaCommand(
                execute: async _ =>
                {
                    var ticket = new Ticket()
                    {
                        PassengersId = SelectedPassenger
                       
                    };
                    await _context.ticket.InsertAsync(UIMappers.MapUITicketToBLLTicket(ticket));
                },
                canExecute: _ => SelectedAirplane is not null && SelectedPassenger is not null
            );
            CommandClear = new LambdaCommand(
                execute: _ =>
                {
                    SelectedAirplane = null;
                    SelectedPassenger = null;
                },
                canExecute: _ => SelectedAirplane is not null || SelectedPassenger is not null
            );
        }
    }
}
