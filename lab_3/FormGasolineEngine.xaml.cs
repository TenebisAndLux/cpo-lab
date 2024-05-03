using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace lab_3
{ 
  /// <summary>
  /// Interaction logic for FormGasolineEngine.xaml
  /// </summary>
  public partial class FormGasolineEngine : Window
  {
    /// <summary>
    /// Gasoline engine for editing
    /// </summary>
    private readonly GasolineEngine _gasolineEngine;

    /// <summary>
    /// Constructor for the form for working with Gasoline engine with specified operating mode.
    /// </summary>
    /// <param name="parGasolineEngine">Gasoline engine for editing</param>
    /// <exception cref="ArgumentNullException">Raised when Gasoline engine is null</exception>
    public FormGasolineEngine(GasolineEngine parGasolineEngine)
    {
      if (parGasolineEngine == null)
        throw new ArgumentNullException(nameof(parGasolineEngine));

      InitializeComponent();

      comboBoxIgnitionType.ItemsSource = Enum.GetValues(typeof(IgnitionType));
      comboBoxFuelType.ItemsSource = Enum.GetValues(typeof(FuelType));

      _gasolineEngine = parGasolineEngine;

      Title = $"Gasoline engine {_gasolineEngine.Id}";
      DataContext = parGasolineEngine;
    }

    // <summary>
    /// Synchronizes data from form fields.
    /// </summary>
    private void SyncData()
    {
      _gasolineEngine.EngineSpecification = new EngineSpecification()
      {
        Power = Convert.ToUInt32(textBoxPower.Text),
        Torque = (float)Convert.ToDouble(textBoxTorque.Text)
      };

      _gasolineEngine.Brand = new Brand()
      {
        Manufacturer = textBoxManufacturer.Text,
        Model = textBoxModel.Text
      };
      _gasolineEngine.VVTLevel = (float)Convert.ToDouble(textBoxVVTLevel.Text, CultureInfo.CurrentCulture);
      _gasolineEngine.AirFuelRatio = (float)Convert.ToDouble(textBoxAirFuelRatio.Text, CultureInfo.CurrentCulture);
      _gasolineEngine.OctaneRating = (float)Convert.ToDouble(textBoxParOctaneRating.Text, CultureInfo.CurrentCulture);
      _gasolineEngine.Сylinders = Convert.ToInt16(textBoxCylinders.Text, CultureInfo.CurrentCulture);
      _gasolineEngine.IgnitionType = (IgnitionType)comboBoxIgnitionType.SelectedItem;
      _gasolineEngine.FuelType = (FuelType)comboBoxFuelType.SelectedItem;
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
      textBoxVVTLevel.Text = _gasolineEngine.VVTLevel.ToString(CultureInfo.CurrentCulture);
      textBoxAirFuelRatio.Text = _gasolineEngine.AirFuelRatio.ToString(CultureInfo.CurrentCulture);
      textBoxParOctaneRating.Text = _gasolineEngine.OctaneRating.ToString(CultureInfo.CurrentCulture);
      textBoxCylinders.Text = _gasolineEngine.Сylinders.ToString(CultureInfo.CurrentCulture);
      comboBoxIgnitionType.Text = _gasolineEngine.IgnitionType.ToString();
      comboBoxFuelType.Text = _gasolineEngine.FuelType.ToString();
      textBoxPower.Text = _gasolineEngine.EngineSpecification.Power.ToString(CultureInfo.CurrentCulture);
      textBoxTorque.Text = _gasolineEngine.EngineSpecification.Torque.ToString(CultureInfo.CurrentCulture);
      textBoxManufacturer.Text = _gasolineEngine.Brand.Manufacturer;
      textBoxModel.Text = _gasolineEngine.Brand.Model;
    }
  }
}