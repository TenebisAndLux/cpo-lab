using System;
using System.Globalization;
using System.Windows;

namespace lab_3
{
  /// <summary>
  /// Interaction logic for FormGasTurbine.xaml
  /// </summary>
  public partial class FormGasTurbine : Window
  {
    /// <summary>
    /// Gas turbine for editing
    /// </summary>
    private readonly GasTurbine _gasTurbine;

    /// <summary>
    /// Constructor for the form for working with Gas turbine with specified operating mode.
    /// </summary>
    /// <param name="parGasTurbine">Gas turbine for editing</param>
    /// <exception cref="ArgumentNullException">Raised when Gas turbine is null</exception>
    public FormGasTurbine(GasTurbine parGasTurbine)
    {
      if (parGasTurbine == null)
        throw new ArgumentNullException(nameof(parGasTurbine));

      InitializeComponent();

      _gasTurbine = parGasTurbine;

      Title = $"Gas turbine {_gasTurbine.Id}";
      DataContext = parGasTurbine;
    }

    /// <summary>
    /// Synchronizes form fields with data.
    /// </summary>
    private void SyncFields()
    {
      textBoxId.Text = _gasTurbine.Id.ToString();
      textBoxPower.Text = _gasTurbine.EngineSpecification.Power.ToString(CultureInfo.CurrentCulture);
      textBoxTorque.Text = _gasTurbine.EngineSpecification.Torque.ToString(CultureInfo.CurrentCulture);
      textBoxManufacturer.Text = _gasTurbine.Brand.Manufacturer;
      textBoxCombustionTemperature.Text = _gasTurbine.CombustionTemperature.ToString(CultureInfo.CurrentCulture);
      textBoxMaxRPM.Text = _gasTurbine.MaxRPM.ToString(CultureInfo.CurrentCulture);
      textBoxInletTemperature.Text = _gasTurbine.InletTemperature.ToString(CultureInfo.CurrentCulture);
      textBoxModel.Text = _gasTurbine.Brand.Model;
      textBoxExhaustGasSpeed.Text = _gasTurbine.ExhaustGasSpeed.ToString(CultureInfo.CurrentCulture);
      textBoxEfficiency.Text = _gasTurbine.Efficiency.ToString(CultureInfo.CurrentCulture);
      textBoxFuelFlowRate.Text = _gasTurbine.FuelFlowRate.ToString(CultureInfo.CurrentCulture);
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
    private void SyncData()
    {
      _gasTurbine.EngineSpecification = new EngineSpecification() { Power = Convert.ToUInt32(textBoxPower.Text), Torque = (float)Convert.ToDouble(textBoxTorque.Text) };
      _gasTurbine.Brand = new Brand() { Manufacturer = textBoxManufacturer.Text, Model = textBoxModel.Text };
      _gasTurbine.CombustionTemperature = (float)Convert.ToDouble(textBoxCombustionTemperature.Text, CultureInfo.CurrentCulture);
      _gasTurbine.MaxRPM = (float)Convert.ToDouble(textBoxMaxRPM.Text, CultureInfo.CurrentCulture);
      _gasTurbine.InletTemperature = (float)Convert.ToDouble(textBoxEfficiency.Text, CultureInfo.CurrentCulture);
      _gasTurbine.ExhaustGasSpeed = (float)Convert.ToDouble(textBoxExhaustGasSpeed.Text, CultureInfo.CurrentCulture);
      _gasTurbine.Efficiency = (float)Convert.ToDouble(textBoxEfficiency.Text, CultureInfo.CurrentCulture);
      _gasTurbine.FuelFlowRate = (float)Convert.ToDouble(textBoxFuelFlowRate.Text, CultureInfo.CurrentCulture);
    }
  }
}