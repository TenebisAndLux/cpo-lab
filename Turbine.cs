/// <summary>
/// Turbine engine class
/// </summary>
public class Turbine : Engine
{
  /// <summary>
  /// Turbine efficiency.
  /// </summary>
  private float _efficiency;

  /// <summary>
  /// Maximum revolutions per minute for the turbine.
  /// </summary>
  private float _maxRPM;

  /// <summary>
  /// Inlet temperature of the turbine.
  /// </summary>
  public float InletTemperature { get; private set; }

  /// <summary>
  /// Inlet pressure of the turbine.
  /// </summary>
  public float InletPressure { get; protected set; }

  /// <summary>
  /// Constructor for the Turbine class.
  /// </summary>
  /// <param name="brand"></param>
  /// <param name="engineSpecification"></param>
  /// <param name="efficiency"></param>
  /// <param name="maxRPM"></param>
  /// <param name="inletTemperature"></param>
  /// <param name="inletPressure"></param>
  public Turbine(Brand brand, EngineSpecification engineSpecification, float efficiency, float maxRPM, float inletTemperature, float inletPressure)
  : base(brand, engineSpecification)
  {
    _efficiency = efficiency;
    _maxRPM = maxRPM;
    InletTemperature = inletTemperature;
    InletPressure = inletPressure;
  }

  /// <summary>
  /// Increases the revolutions per minute of the turbine by the specified amount.
  /// </summary>
  public void IncreaseRPM(float amount)
  {
    _maxRPM += amount;
    Console.WriteLine($"RPM increased by {amount}.");
  }

  /// <summary>
  /// Decreases the revolutions per minute of the turbine by the specified amount.
  /// </summary>
  public void DecreaseRPM(float amount)
  {
    _maxRPM -= amount;
    Console.WriteLine($"RPM decreased by {amount}.");
  }
}