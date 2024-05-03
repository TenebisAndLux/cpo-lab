using System;
using System.Globalization;
using System.Windows;

namespace lab_3
{
  /// <summary>
  /// Form for working with steam turbine with specified operating mode.
  /// </summary>
  public partial class FormSteamTurbine : Window
  {
    /// <summary>
    /// Steam turbine for editing
    /// </summary>
    private readonly SteamTurbine _steamTurbine;

    /// <summary>
    /// Constructor for the form for working with steam turbine with specified operating mode.
    /// </summary>
    /// <param name="parSteamTurbine">Steam turbine for editing</param>
    /// <exception cref="ArgumentNullException">Raised when steam turbine is null</exception>
    public FormSteamTurbine(SteamTurbine parSteamTurbine)
    {
      if (parSteamTurbine == null)
        throw new ArgumentNullException(nameof(parSteamTurbine));

      InitializeComponent();

      _steamTurbine = parSteamTurbine;

      Title = $"Steam turbine {_steamTurbine.Id}";
      DataContext = parSteamTurbine;
    }

    /// <summary>
    /// Synchronizes form fields with data.
    /// </summary>
    private void SyncFields()
    {
      textBoxId.Text = _steamTurbine.Id.ToString();
      textBoxTurbineBladeLength.Text = _steamTurbine.TurbineBladeLength.ToString(CultureInfo.CurrentCulture);
      textBoxSteamFlowRate.Text = _steamTurbine.SteamFlowRate.ToString(CultureInfo.CurrentCulture);
      textBoxMaxSteamVelocity.Text = _steamTurbine.MaxSteamVelocity.ToString(CultureInfo.CurrentCulture);
      textBoxSteamQuality.Text = _steamTurbine.SteamQuality.ToString(CultureInfo.CurrentCulture);
      textBoxPower.Text = _steamTurbine.EngineSpecification.Power.ToString(CultureInfo.CurrentCulture);
      textBoxTorque.Text = _steamTurbine.EngineSpecification.Torque.ToString(CultureInfo.CurrentCulture);
      textBoxEfficiency.Text = _steamTurbine.Efficiency.ToString(CultureInfo.CurrentCulture);
      textBoxManufacturer.Text = _steamTurbine.Brand.Manufacturer;
      textBoxModel.Text = _steamTurbine.Brand.Model;
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
      _steamTurbine.TurbineBladeLength = (float)Convert.ToDouble(textBoxTurbineBladeLength.Text, CultureInfo.CurrentCulture);
      _steamTurbine.SteamFlowRate = (float)Convert.ToDouble(textBoxSteamFlowRate.Text, CultureInfo.CurrentCulture);
      _steamTurbine.MaxSteamVelocity = (float)Convert.ToDouble(textBoxMaxSteamVelocity.Text, CultureInfo.CurrentCulture);
      _steamTurbine.SteamQuality = (float)Convert.ToDouble(textBoxSteamQuality.Text, CultureInfo.CurrentCulture);
      _steamTurbine.EngineSpecification = new EngineSpecification() { Power = Convert.ToUInt32(textBoxPower.Text), Torque = (float)Convert.ToDouble(textBoxTorque.Text)};
      _steamTurbine.Brand = new Brand() { Manufacturer = textBoxManufacturer.Text, Model = textBoxModel.Text };
      _steamTurbine.Efficiency = (float)Convert.ToDouble(textBoxEfficiency.Text, CultureInfo.CurrentCulture);
    }
  }
}

