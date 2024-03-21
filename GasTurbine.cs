/// <summary>
/// Gas turbine engine class
/// </summary>
public class GasTurbine : Turbine
{
  /// <summary>
  /// Flow rate of fuel entering the turbine for combustion.
  /// </summary>
  public float FuelFlowRate { get; private set; }

  /// <summary>
  /// Temperature of combustion in the turbine.
  /// </summary>
  public float CombustionTemperature { get; private set; }

  /// <summary>
  /// Inlet pressure of the gas turbine.
  /// </summary>
  private float _turbineInletPressure;

  /// <summary>
  /// Efficiency of the gas turbine.
  /// </summary>
  public float Efficiency { get; private set; }

  /// <summary>
  /// Maximum power output of the gas turbine.
  /// </summary>
  private float _maxPowerOutput;

  /// <summary>
  /// Speed of exhaust gases leaving the gas turbine.
  /// </summary>
  public float ExhaustGasSpeed { get; private set; }

  /// <summary>
  /// Constructor for the GasTurbine class.
  /// </summary>
  public GasTurbine(Brand brand, EngineSpecification engineSpecification, float efficiency, float maxRPM, float inletTemperature, float inletPressure, float turbineInletPressure)
          : base(brand, engineSpecification, efficiency, maxRPM, inletTemperature, inletPressure)
  {
    _maxPowerOutput = CalculateMaxPowerOutput();
    ExhaustGasSpeed = CalculateExhaustGasSpeed();
    Efficiency = CalculateEfficiency();
    _turbineInletPressure = turbineInletPressure;
  }

  /// <summary>
  /// Calculates the maximum power output of the gas turbine based on fuel flow rate and combustion temperature.
  /// </summary>
  /// <returns>Maximum power output of the gas turbine</returns>
  public float CalculateMaxPowerOutput()
  {
    // Max power output = fuel flow rate * combustion temperature
    _maxPowerOutput = FuelFlowRate * CombustionTemperature;
    return _maxPowerOutput;
  }

  /// <summary>
  /// Calculates the speed of exhaust gases leaving the gas turbine based on efficiency and inlet pressure.
  /// </summary>
  /// <returns>Speed of exhaust gases leaving the gas turbine</returns>
  public float CalculateExhaustGasSpeed()
  {
    // Exhaust gas speed = efficiency * inlet pressure
    ExhaustGasSpeed = Efficiency * InletPressure;
    return ExhaustGasSpeed;
  }

  /// <summary>
  /// Calculates and sets the efficiency of the gas turbine based on fuel flow rate and combustion temperature.
  /// </summary>
  public float CalculateEfficiency()
  {
    // Efficiency calculation logic based on fuel flow rate and combustion temperature
    Efficiency = (FuelFlowRate + CombustionTemperature) * 0.5f;
    return Efficiency;
  }

  /// <summary>
  /// Increases the combustion temperature in the gas turbine by the specified amount.
  /// </summary>
  public void IncreaseCombustionTemperature(float temperature)
  {
    CombustionTemperature += temperature;
    Console.WriteLine($"Combustion temperature increased by {temperature}.");
  }
}