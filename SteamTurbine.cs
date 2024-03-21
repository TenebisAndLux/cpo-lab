/// <summary>
/// Steam turbine engine class
/// </summary>
public class SteamTurbine : Turbine
{
  /// <summary>
  /// Flow rate of steam entering the turbine.
  /// </summary>
  private float _steamFlowRate;

  /// <summary>
  /// Length of turbine blades.
  /// </summary>
  private float _turbineBladeLength;

  /// <summary>
  /// Quality of steam being used in the turbine.
  /// </summary>
  public float SteamQuality { get; private set; }

  /// <summary>
  /// Maximum velocity of steam within the turbine.
  /// </summary>
  private float _maxSteamVelocity;

  /// <summary>
  /// Constructor for the SteamTurbine class.
  /// </summary>
  /// <param name="steamFlowRate"></param>
  /// <param name="turbineBladeLength"></param>
  /// <param name="maxSteamVelocity"></param>
  /// <param name="brand"></param>
  /// <param name="engineSpecification"></param>
  /// <param name="efficiency"></param>
  /// <param name="maxRPM"></param>
  /// <param name="inletTemperature"></param>
  /// <param name="inletPressure"></param>
  public SteamTurbine(float steamFlowRate, float turbineBladeLength,float maxSteamVelocity, 
  Brand brand, EngineSpecification engineSpecification, float efficiency, float maxRPM, float inletTemperature, float inletPressure)
          : base(brand, engineSpecification, efficiency, maxRPM, inletTemperature, inletPressure)
  {
    _maxSteamVelocity = maxSteamVelocity;
    _steamFlowRate = steamFlowRate;
    _turbineBladeLength = turbineBladeLength;
  }

  /// <summary>
  /// Calculates the total torque produced by the turbine based on steam flow rate and blade length.
  /// </summary>
  /// <returns>Total torque produced by the turbine</returns>
  public float CalculateTorque()
  {
    // Torque = steam flow rate * turbine blade length
    float torque = _steamFlowRate * _turbineBladeLength;
    return torque;
  }

  /// <summary>
  /// Checks if the turbine is operating at maximum efficiency based on its settings.
  /// </summary>
  public void CheckEfficiency()
  {
    if (_steamFlowRate > 500 && InletPressure > 50 && SteamQuality > 0.8)
    {
      Console.WriteLine("Turbine operating at maximum efficiency.");
    }
    else
    {
      Console.WriteLine("Turbine efficiency can be improved with optimal settings.");
    }
  }

  /// <summary>
  /// Increases the inlet pressure of steam entering the turbine by the specified amount.
  /// </summary>
  public void IncreaseInletPressure(float pressure)
  {
    InletPressure += pressure;
    Console.WriteLine($"Inlet pressure increased by {pressure}.");
  }

  /// <summary>
  /// Monitors the steam quality for optimal turbine performance.
  /// </summary>
  public void MonitorSteamQuality()
  {
    Console.WriteLine("Monitoring steam quality for optimal turbine performance.");
  }
}