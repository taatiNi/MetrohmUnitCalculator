using Metrohm.UI.MVVM.ViewModel;
using Metrohm_Unit.Core; 
using System.Collections.ObjectModel; 

namespace Metrohm_Unit.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _units;
        public ObservableCollection<Unit> Units
        {
            get => _units;
            set
            {
                _units = value;
                OnPropertyChanged(nameof(Units));
            }
        }
        private UnitType _unitType;

        public UnitType UnitType
        {
            get => _unitType;
            set
            {
                if (_unitType != value)
                {
                    _unitType = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _doubleValue;

        public double DoubleValue
        {
            get => _doubleValue;
            set
            {
                if (_doubleValue != value)
                {
                    _doubleValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand WindowLoadedCommand { get; set; }

        public MainViewModel() : base()
        {
            DoubleValue = 1;
            UnitType = UnitType.MiliSecond;

            WindowLoadedCommand = new RelayCommand(x =>
            {
                Units = new ObservableCollection<Unit> {
                new Unit(UnitType.Second, "Second"),
                new Unit(UnitType.MiliSecond, "Mili Second")
            };
            });
        }
    }
}
