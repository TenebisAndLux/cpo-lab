/// <summary>
/// Gasoline engine class
/// </summary>
public class GasolineEngine : InternalCombustionEngine
{
  /// <summary>
  /// Octane rating of the gasoline used in the engine.
  /// </summary>
  public float OctaneRating { get; private set; }

  /// <summary>
  /// Air-fuel ratio in the engine.
  /// </summary>
  private float _airFuelRatio;

  /// <summary>
  /// Maximum power output of the gasoline engine.
  /// </summary>
  private float _maxPower;

  /// <summary>
  /// Level of Variable Valve Timing in the engine.
  /// </summary>
  private float _vvtLevel;

  /// <summary>
  /// Constructor for the GasolineEngine class.
  /// </summary>
  /// <param name="vvtLevel"></param>
  /// <param name="airFuelRatio"></param>
  /// <param name="octaneRating"></param>
  /// <param name="brand"></param>
  /// <param name="engineSpecification"></param>
  /// <param name="cylinders"></param>
  /// <param name="fuelType"></param>
  /// <param name="ignitionType"></param>
  public GasolineEngine(float vvtLevel, float airFuelRatio, float octaneRating, Brand brand, 
  EngineSpecification engineSpecification, int cylinders, FuelType fuelType, IgnitionType ignitionType)
      : base(brand, engineSpecification, cylinders, fuelType, ignitionType)
  {
    _maxPower = CalculateMaxPowerOutput();
    _vvtLevel = vvtLevel;
    _airFuelRatio = airFuelRatio;
    OctaneRating = octaneRating;
  }

  /// <summary>
  /// Generates engine sound based on the current state of the gasoline engine.
  /// </summary>
  public void GenerateEngineSound()
  {
    // Calculate sound based on engine parameters
    double soundLevel = _maxPower * _vvtLevel / 100;

    if (soundLevel > 50)
    {
      Console.WriteLine("Loud engine sound!");
    }
    else if (soundLevel > 20)
    {
      Console.WriteLine("Normal engine sound.");
    }
    else
    {
      Console.WriteLine("Quiet engine sound.");
    }
  }

  /// <summary>
  /// Calculates the efficiency of the gasoline engine based on its parameters.
  /// </summary>
  /// <returns> efficiency </returns>
  public double CalculateEfficiency()
  {
    // Complex calculations for engine efficiency
    double efficiency = (_maxPower * 0.8) + (Сylinders * 0.6) + (OctaneRating);

    // Additional calculations based on engine state
    if (_vvtLevel > 50)
    {
      efficiency *= 1.2;
    }
    else
    {
      efficiency *= 0.8;
    }

    // Update efficiency based on engine temperature
    if (_airFuelRatio > 90)
    {
      efficiency *= 0.9;
    }
    else if (_airFuelRatio < 70)
    {
      efficiency *= 1.1;
    }

    return efficiency;
  }

  /// <summary>
  /// Calculates and sets the maximum power output of the gasoline engine.
  /// </summary>
  /// <returns> _maxPower </returns>
  public float CalculateMaxPowerOutput()
  {
    // Calculation logic based on engine parameters
    _maxPower = Сylinders * _airFuelRatio * OctaneRating;
    return _maxPower;
  }
}