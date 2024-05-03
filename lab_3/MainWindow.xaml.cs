using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace lab_3
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    /// <summary>
    /// List of engines
    /// </summary>
    private ObservableCollection<Engine> _engines = new ObservableCollection<Engine>();

    /// <summary>
    /// Random generator
    /// </summary>
    private Random _random = new();

    /// <summary>
    /// Main window constructor
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
      dataGridEngines.DataContext = _engines;
    }

    /// <summary>
    /// Checks if the index is valid
    /// </summary>
    /// <param name="parIndex"> Index </param>
    /// <returns> True if the index is valid, otherwise - false </returns>
    private bool IsValidIndex(int parIndex)
    {
      return _engines.Count > 0 && parIndex >= 0 && parIndex < _engines.Count;
    }

    /// <summary>
    /// Returns the selected engine
    /// </summary>
    /// <returns> Selected tool </returns>
    private Engine? GetSelectedItem()
    {
      if (!IsValidIndex(dataGridEngines.SelectedIndex))
        return null;

      return _engines[dataGridEngines.SelectedIndex];
    }

    /// <summary>
    /// Changing the state of the "Delete" and "Edit" buttons
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridEngines_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      bool isActionsEnabled = (dataGridEngines.SelectedIndex >= 0 && _engines.Count != 0);
      menuItemUpdate.IsEnabled = menuItemDelete.IsEnabled = buttonUpdate.IsEnabled = buttonDelete.IsEnabled = isActionsEnabled;
    }

    /// <summary>
    /// Opens the editing form
    /// </summary>
    /// <param name="parEngine"> Engine </param>
    /// <returns> True if editing was successful, otherwise - false </returns>
    private bool ShowEditForm(Engine parEngine)
    {
      Window? form = parEngine switch
      {
        GasolineEngine gasolineEngine => new FormGasolineEngine(gasolineEngine),
        DieselEngine dieselEngine => new FormDieselEngine(dieselEngine),
        GasTurbine gasTurbine => new FormGasTurbine(gasTurbine),
        SteamTurbine steamTurbine => new FormSteamTurbine(steamTurbine),
        _ => null,
      };

      if (form == null)
        return false;

      var result = form.ShowDialog();

      dataGridEngines.Items.Refresh();

      return result ?? false;
    }

    /// <summary>
    /// Generates a random engine
    /// </summary>
    /// <returns>Random engine</returns>
    private Engine GenerateEngine()
    {
      Brand brand = new Brand()
      {
        Manufacturer = "Manufacturer" + _random.Next(1, 100),
        Model = "Model" + _random.Next(1, 100)
      };

      EngineSpecification engineSpec = new EngineSpecification()
      {
        Power = (uint)_random.Next(100, 500),
        Torque = (float)_random.NextDouble() * 100
      };

      return new Engine(ref brand, ref engineSpec);
    }

    /// <summary>
    /// Generates a random turbine
    /// </summary>
    /// <returns>Random turbine</returns>
    private SteamTurbine GenerateSteamTurbine()
    {
      float steamFlowRate = (float)_random.NextDouble() * 100;
      float turbineBladeLength = (float)_random.NextDouble() * 10;
      float maxSteamVelocity = (float)_random.NextDouble() * 50;

      Brand brand = new Brand()
      {
        Manufacturer = "Manufacturer" + _random.Next(1, 100),
        Model = "Model" + _random.Next(1, 100)
      };

      EngineSpecification engineSpec = new EngineSpecification()
      {
        Power = (uint)_random.Next(100, 500),
        Torque = (float)_random.NextDouble() * 100
      };

      float efficiency = (float)_random.NextDouble();
      float maxRPM = (float)_random.Next(1000, 5000);
      float inletTemperature = (float)_random.NextDouble() * 100;
      float inletPressure = (float)_random.Next(10, 50);

      return new SteamTurbine(steamFlowRate, turbineBladeLength, maxSteamVelocity,
          brand, engineSpec, efficiency, maxRPM, inletTemperature, inletPressure);
    }

    /// <summary>
    /// Generates a random turbine
    /// </summary>
    /// <returns>Random turbine</returns>
    private GasTurbine GenerateGasTurbine()
    {
      float fuelFlowRate = (float)_random.NextDouble() * 100;
      float combustionTemperature = (float)_random.NextDouble() * 100;
      float efficiency = (float)_random.NextDouble();
      float maxRPM = (float)_random.Next(1000, 5000);
      float inletTemperature = (float)_random.NextDouble() * 100;
      float inletPressure = (float)_random.Next(10, 50);
      float turbineInletPressure = (float)_random.Next(10, 50);

      Brand brand = new Brand()
      {
        Manufacturer = "Manufacturer" + _random.Next(1, 100),
        Model = "Model" + _random.Next(1, 100)
      };

      EngineSpecification engineSpec = new EngineSpecification()
      {
        Power = (uint)_random.Next(100, 500),
        Torque = (float)_random.NextDouble() * 100
      };

      return new GasTurbine(brand, engineSpec, fuelFlowRate, combustionTemperature, efficiency, maxRPM, inletTemperature, inletPressure, turbineInletPressure);
    }

    /// <summary>
    /// Generates a random internal combustion engine
    /// </summary>
    /// <returns>Random internal combustion engine</returns>
    private DieselEngine GenerateDieselEngine()
    {
      int cylinders = _random.Next(4, 8);
      FuelType randomFuelType = (FuelType)_random.Next(0, Enum.GetValues(typeof(FuelType)).Length);
      IgnitionType randomIgnitionType = (IgnitionType)_random.Next(0, Enum.GetValues(typeof(IgnitionType)).Length);
      float injectorPressure = (float)_random.Next(10, 50);
      float turboPressure = (float)_random.Next(10, 30);

      Brand brand = new Brand()
      {
        Manufacturer = "Manufacturer" + _random.Next(1, 100),
        Model = "Model" + _random.Next(1, 100)
      };

      EngineSpecification engineSpec = new EngineSpecification()
      {
        Power = (uint)_random.Next(100, 500),
        Torque = (float)_random.NextDouble() * 100
      };

      return new DieselEngine(brand, engineSpec, cylinders, randomFuelType, randomIgnitionType, injectorPressure, turboPressure);
    }

    /// <summary>
    /// Generates a random internal combustion engine
    /// </summary>
    /// <returns>Random internal combustion engine</returns>
    private GasolineEngine GenerateGasolineEngine()
    {
      float vvtLevel = (float)_random.NextDouble() * 10;
      float airFuelRatio = (float)_random.NextDouble() * 20;
      float octaneRating = _random.Next(87, 95);

      Brand brand = new Brand()
      {
        Manufacturer = "Manufacturer" + _random.Next(1, 100),
        Model = "Model" + _random.Next(1, 100)
      };

      EngineSpecification engineSpec = new EngineSpecification()
      {
        Power = (uint)_random.Next(100, 500),
        Torque = (float)_random.NextDouble() * 100
      };

      int cylinders = _random.Next(4, 8);
      FuelType randomFuelType = (FuelType)_random.Next(0, Enum.GetValues(typeof(FuelType)).Length);
      IgnitionType randomIgnitionType = (IgnitionType)_random.Next(0, Enum.GetValues(typeof(IgnitionType)).Length);

      return new GasolineEngine(vvtLevel, airFuelRatio, octaneRating, brand, engineSpec, cylinders, randomFuelType, randomIgnitionType);
    }

    /// <summary>
    /// Adds a gas turbine engine to the list of engines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddGasTurbine_Click(object sender, RoutedEventArgs e)
    {
      var gasTurbine = new GasTurbine(new Brand { Manufacturer = "General", Model = "Enercon E82" }, new EngineSpecification { Power = 1200, Torque = 200 }, 1000, 500, 0, 100, 50, 0, 100);

      if (ShowEditForm(gasTurbine))
        _engines.Add(gasTurbine);
    }
    /// <summary>
    /// Adds a steam turbine engine to the list of engines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddSteamTurbine_Click(object sender, RoutedEventArgs e)
    {
      var steamTurbine = new SteamTurbine(1000, 500, 30, new Brand { Manufacturer = "WindTurbine", Model = "Enercon E82" }, new EngineSpecification { Power = 1000, Torque = 500 }, 500, 0, 100, 50);

      if (ShowEditForm(steamTurbine))
        _engines.Add(steamTurbine);
    }
    /// <summary>
    /// Adds a gasoline engine to the list of engines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddGasolineEngine_Click(object sender, RoutedEventArgs e)
    {
      var gasolineEngine = new GasolineEngine(150, 1.0f, 8, new Brand { Manufacturer = "Reference", Model = "S63" }, new EngineSpecification { Power = 150, Torque = 2.0f }, 8, FuelType.Gasoline, IgnitionType.ForcedIgnition);

      if (ShowEditForm(gasolineEngine))
        _engines.Add(gasolineEngine);
    }
    /// <summary>
    /// Adds a diesel engine to the list of engines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddDieselEngine_Click(object sender, RoutedEventArgs e)
    {
      var dieselEngine = new DieselEngine(new Brand { Manufacturer = "Mercedes", Model = "CL550AMG" }, new EngineSpecification { Power = 100, Torque = 3.0f }, 12, FuelType.Diesel, IgnitionType.SelfIgnition, 300, 500);

      if (ShowEditForm(dieselEngine))
        _engines.Add(dieselEngine);
    }

    /// <summary>
    /// Generating test entries into the list of engines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonGenerateTestRecords_Click(object sender, RoutedEventArgs e)
    {
      Engine engine = _random.Next(0, 4) switch
      {
        0 => GenerateEngine(),
        1 => GenerateGasTurbine(),
        2 => GenerateSteamTurbine(),
        3 => GenerateGasolineEngine(),
        _ => GenerateDieselEngine(),
      };

      _engines.Add(engine);

      //_engines.Clear();

      //Engine gasolineEngine = new GasolineEngine(150, 2.0f, 8, new Brand { Manufacturer = "Reference", Model = "S63" }, new EngineSpecification { Power = 150, Torque = 2.0f }, 8, FuelType.Gasoline, IgnitionType.ForcedIgnition);
      //Engine dieselEngine = new DieselEngine(new Brand { Manufacturer = "Mercedes", Model = "CL550AMG" }, new EngineSpecification { Power = 100, Torque = 3.0f }, 12, FuelType.Diesel, IgnitionType.SelfIgnition, 300, 500);
      //Engine steamTurbine = new SteamTurbine(1000, 500, 30, new Brand { Manufacturer = "WindTurbine", Model = "Enercon E82" }, new EngineSpecification { Power = 1000, Torque = 500 }, 500, 0.5f, 100.0f, 50.0f);
      //Engine gasTurbine = new GasTurbine(new Brand { Manufacturer = "General", Model = "" }, new EngineSpecification { Power = 1200, Torque = 200 }, 1000, 500, 0.5f, 100.0f, 50.0f, 0.5f, 100.0f);

      //_engines.Add(gasolineEngine);
      //_engines.Add(dieselEngine);
      //_engines.Add(steamTurbine);
      //_engines.Add(gasTurbine);
    }

    /// <summary>
    /// Event handler for clicking the "Delete" button
    /// </summary>
    private void ButtonDelete_Click(object sender, RoutedEventArgs e)
    {
      if (!IsValidIndex(dataGridEngines.SelectedIndex))
        return;

      _engines.RemoveAt(dataGridEngines.SelectedIndex);
    }

    /// <summary>
    /// Event handler for clicking the "Edit" button
    /// </summary>
    private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
    {
      var item = GetSelectedItem();
      if (item == null)
        return;

      ShowEditForm(item);
    }
  }
}
