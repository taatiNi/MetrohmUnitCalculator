using Metrohm_Unit.Helper;
using Metrohm_Unit.ViewModel; 
using System.Collections.ObjectModel;
using System.Linq; 
using System.Windows;
using System.Windows.Controls; 

namespace Metrohm_Unit.UserControls
{
    /// <summary>
    /// Interaction logic for UnitUc.xaml
    /// </summary>
    public partial class UnitUc : UserControl
    {

        public UnitUc()
        {
            InitializeComponent();
        }


        #region Dependency Prperty

        public string DisplayValue
        {
            get { return (string)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }

        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(string), typeof(UnitUc), new PropertyMetadata(""));

        public ObservableCollection<Unit> Units
        {
            get { return (ObservableCollection<Unit>)GetValue(UnitsProperty); }
            set { SetValue(UnitsProperty, value); }
        }

        public static readonly DependencyProperty UnitsProperty =
            DependencyProperty.Register("Units", typeof(ObservableCollection<Unit>), typeof(UnitUc), new PropertyMetadata(null, onUnitsChanged));

        public Unit SelectedUnit
        {
            get { return (Unit)GetValue(SelectedUnitProperty); }
            set { SetValue(SelectedUnitProperty, value); }
        }

        public static readonly DependencyProperty SelectedUnitProperty =
            DependencyProperty.Register("SelectedUnit", typeof(Unit), typeof(UnitUc), new PropertyMetadata(null, onSelectedChanged));

        public double DoubleValue
        {
            get { return (double)GetValue(DoubleValueProperty); }
            set { SetValue(DoubleValueProperty, value); }
        }
        public static readonly DependencyProperty DoubleValueProperty =
            DependencyProperty.Register("DoubleValue", typeof(double), typeof(UnitUc), new PropertyMetadata(0.0, onDoubleValueChanged));

        public double CurretDoubleValue { get; set; } = 0;

        #endregion

        #region OnChanged
        private static void onDoubleValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UnitUc unitUs = (UnitUc)d; 
            ((UnitUc)d).UpdateCurrentDoubleValue((double)e.NewValue); 
        }

        private static void onUnitsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var list = (ObservableCollection<Unit>)e.NewValue;
            if (list != null)
                ((UnitUc)d).SelectedUnit = list.FirstOrDefault();
        }


        private static void onSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UnitUc unitUs = (UnitUc)d;
            UnitType oldValue = (Unit)e.OldValue == null ? UnitType.Second : ((Unit)e.OldValue).Type; 
            unitUs.SetDisplayValue(oldValue, ((Unit)e.NewValue).Type);

        }

        #endregion

        #region
        public void SetDisplayValue(UnitType oldValue, UnitType newValue)
        {
            CurretDoubleValue = UnitConverter.Convert(oldValue, newValue, CurretDoubleValue);
            SetDisplayValue();
        }
        public void SetDisplayValue()
        {
            if (SelectedUnit != null)
                DisplayValue = $"{CurretDoubleValue} {SelectedUnit.Title}";
        }
        public void UpdateCurrentDoubleValue(double newValue)
        {
            CurretDoubleValue = newValue;
            SetDisplayValue();
        }
        #endregion
    }
}
