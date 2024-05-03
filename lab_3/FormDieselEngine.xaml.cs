using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace lab_3
{
  /// <summary>
  /// Interaction logic for FormDieselEngine.xaml
  /// </summary>
  public partial class FormDieselEngine : Window
  {
    /// <summary>
    /// Diesel engine for editing
    /// </summary>
    private readonly DieselEngine _dieselEngine;

    /// <summary>
    /// Constructor for the form for working with Diesel engine with specified operating mode.
    /// </summary>
    /// <param name="parDieselEngine">Diesel engine for editing</param>
    /// <exception cref="ArgumentNullException">Raised when Diesel engine is null</exception>
    public FormDieselEngine(DieselEngine parDieselEngine)
    {
      if (parDieselEngine == null)
        throw new ArgumentNullException(nameof(parDieselEngine));

      InitializeComponent();

      comboBoxIgnitionType.ItemsSource = Enum.GetValues(typeof(IgnitionType));
      comboBoxFuelType.ItemsSource = Enum.GetValues(typeof(FuelType));

      _dieselEngine = parDieselEngine;

      Title = $"Diesel engine {_dieselEngine.Id}";
      DataContext = parDieselEngine;
    }

    /// <summary>
    /// Synchronizes data from form fields.
    /// </summary>
    private void SyncData()
    {
      _dieselEngine.EngineSpecification = new EngineSpecification()
      {
        Power = Convert.ToUInt32(textBoxPower.Text),
        Torque = (float)Convert.ToDouble(textBoxTorque.Text)
      };

      _dieselEngine.Brand = new Brand()
      {
        Manufacturer = textBoxManufacturer.Text,
        Model = textBoxModel.Text
      };
      _dieselEngine.TurboPressure = (float)Convert.ToDouble(textBoxTurboPressure.Text, CultureInfo.CurrentCulture);
      _dieselEngine.InjectorPressure = (float)Convert.ToDouble(textBoxInjectorPressure.Text, CultureInfo.CurrentCulture);
      _dieselEngine.Сylinders = Convert.ToInt16(textBoxCylinders.Text, CultureInfo.CurrentCulture);
      _dieselEngine.IgnitionType = (IgnitionType)comboBoxIgnitionType.SelectedItem;
      _dieselEngine.FuelType = (FuelType)comboBoxFuelType.SelectedItem;
    }

    /// <summary>
    /// Handles click on "Ok" button.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonFormAction_Click(object sender, RoutedEventArgs e)
    {
      SyncData();
      DialogResult = true;
    }

    /// <summary>
    /// Synchronizes data from form fields.
    /// </summary>
    private void SyncFields()
    {
      textBoxTurboPressure.Text = _dieselEngine.TurboPressure.ToString(CultureInfo.CurrentCulture);
      textBoxInjectorPressure.Text = _dieselEngine.InjectorPressure.ToString(CultureInfo.CurrentCulture);
      textBoxCylinders.Text = _dieselEngine.Сylinders.ToString(CultureInfo.CurrentCulture);
      comboBoxIgnitionType.Text = _dieselEngine.IgnitionType.ToString();
      comboBoxFuelType.Text = _dieselEngine.FuelType.ToString();
      textBoxPower.Text = _dieselEngine.EngineSpecification.Power.ToString(CultureInfo.CurrentCulture);
      textBoxTorque.Text = _dieselEngine.EngineSpecification.Torque.ToString(CultureInfo.CurrentCulture);
      textBoxManufacturer.Text = _dieselEngine.Brand.Manufacturer;
      textBoxModel.Text = _dieselEngine.Brand.Model;
    }
  }
}


