using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using SimpleHmi.PlcService;
using System.Windows.Input;

namespace Siemens_HMI.ViewModels
{
    class MainWindowViewModel : BindableBase
    {

        //Dichiarazione proprietà dei componenti UI

        // Indirizzo IP PLC

        public string IpAddress
        {
            get { return _ipAddress; }
            set { SetProperty(ref _ipAddress, value); }
        }
        private string _ipAddress;

        // Rack

        public int Rack
        {
            get { return _rack; }
            set { SetProperty(ref _rack, value); }
        }
        private int _rack;

        // Slot

        public int Slot
        {
            get { return _slot; }
            set { SetProperty(ref _slot, value); }
        }
        private int _slot;

        // Limite Alto

        public bool HighLimit
        {
            get { return _highLimit; }
            set { SetProperty(ref _highLimit, value); }
        }
        private bool _highLimit;

        // Limite Basso

        public bool LowLimit
        {
            get { return _lowLimit; }
            set { SetProperty(ref _lowLimit, value); }
        }
        private bool _lowLimit;

        // Stato pompa - Verde se in marcia

        public bool PumpState
        {
            get { return _pumpState; }
            set { SetProperty(ref _pumpState, value); }
        }
        private bool _pumpState;

        public int TankLevel
        {
            get { return _tankLevel; }
            set { SetProperty(ref _tankLevel, value); }
        }
        private int _tankLevel;

        public ConnectionStates ConnectionState
        {
            get { return _connectionState; }
            set { SetProperty(ref _connectionState, value); }
        }
        private ConnectionStates _connectionState;

        public TimeSpan ScanTime
        {
            get { return _scanTime; }
            set { SetProperty(ref _scanTime, value); }
        }
        private TimeSpan _scanTime;


        // Dichiarazione comandi

        public ICommand ConnectCommand { get; private set; }

        public ICommand DisconnectCommand { get; private set; }

        public ICommand StartCommand { get; private set; }

        public ICommand StopCommand { get; private set; }

        

        // Dichiarazione servizio PLC - Consumiamo i dati della vista da questo

        S7PlcService _plcService;

        
        
        // Stabilisco quali azioni fare eseguire ai comandi dichiarati

        private void Connect()
        {
            _plcService.Connect(IpAddress, Rack, Slot);
        }

        private void Disconnect()
        {
            _plcService.Disconnect();
        }

        private async Task Start()
        {
            await _plcService.WriteStart();
        }

        private async Task Stop()
        {
            await _plcService.WriteStop();
        }

        // Costruttore ViewModel vista principale

        public MainWindowViewModel()
        {
            _plcService = new S7PlcService();
            ConnectCommand = new DelegateCommand(Connect);
            DisconnectCommand = new DelegateCommand(Disconnect);
            StartCommand = new DelegateCommand(async () => { await Start(); });
            StopCommand = new DelegateCommand(async () => { await Stop(); });            

            IpAddress = "";

            OnPlcServiceValuesRefreshed(null, null);
            _plcService.ValuesRefreshed += OnPlcServiceValuesRefreshed;
        }

        // Quando il servizio PLC ha finito l'esecuzione , aggiorna la vista

        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            ConnectionState = _plcService.ConnectionState;
            PumpState = _plcService.PumpState;
            HighLimit = _plcService.HighLimit;
            LowLimit = _plcService.LowLimit;
            TankLevel = _plcService.TankLevel;
            ScanTime = _plcService.ScanTime;
        }

    }
}
