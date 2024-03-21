/// <summary>
/// Hybrid engine class
/// </summary>
public class HybridEngine : InternalCombustionEngine
{
  /// <summary>
  /// Capacity of the hybrid engine's battery.
  /// </summary>
  public float BatteryCapacity { get; protected set; }

  /// <summary>
  /// Power of the electric motor in the hybrid engine.
  /// </summary>
  public float ElectricMotorPower { get; private set; }

  /// <summary>
  /// Efficiency of regenerative braking in the hybrid engine.
  /// </summary>
  private float _regenerativeBrakingEfficiency;

  /// <summary>
  /// Threshold for starting the internal combustion engine in the hybrid engine.
  /// </summary>
  private float _engineStartThreshold;

  /// <summary>
  /// Level of charge in the hybrid engine's battery.
  /// </summary>
  public float ChargeLevel { get; private set; }

  /// <summary>
  /// Range of the hybrid engine when running on electric power only.
  /// </summary>
  private float _electricRange;

  /// <summary>
  /// Constructor for the HybridEngine class.
  /// </summary>
  public HybridEngine(float regenerativeBrakingEfficiency, float electricMotorPower, float batteryCapacity, Brand brand, EngineSpecification engineSpecification, int cylinders, FuelType fuelType, IgnitionType ignitionType)
      : base(brand, engineSpecification, cylinders, fuelType, ignitionType)
  {
    BatteryCapacity = batteryCapacity;
    ElectricMotorPower = electricMotorPower;
    _regenerativeBrakingEfficiency = regenerativeBrakingEfficiency;
  }
  /// <summary>
  /// Method to calculate the maximum distance the hybrid engine can travel on electric power only
  /// </summary>
  /// <returns> distance </returns>
  public float CalculateElectricRange()
  {
    // Complex calculations based on battery capacity, electric motor power, and regenerative braking efficiency
    float distance = (float)((BatteryCapacity * 0.1) + (ElectricMotorPower * 0.3) - (_regenerativeBrakingEfficiency * 0.2));

    return distance;
  }

  /// <summary>
  /// Method to calculate the maximum speed of the vehicle based on engine power and charge level
  /// </summary>
  /// <returns> maxSpeed </returns>
  public float CalculateMaxSpeed()
  {
    // Complex calculations based on engine power, charge level, and other factors
    float maxSpeed = (ElectricMotorPower + CalculateEnginePower()) / 1000;

    return maxSpeed;
  }

  /// <summary>
  /// Method to calculate the power of the engine
  /// </summary>
  /// <returns> enginePower </returns>
  private float CalculateEnginePower()
  {
    // Complex calculations based on engine specifications, fuel type, etc.
    float enginePower = Сylinders * 10; // Simplified calculation for demonstration purposes

    return enginePower;
  }

  /// <summary>
  /// Method to determine if the internal combustion engine should start based on the current charge level
  /// </summary>
  /// <returns> If the engine does not have enough energy to start, write false, otherwise true </returns>
  public bool ShouldStartInternalCombustionEngine()
  {
    // Check if charge level is below the engine start threshold
    if (ChargeLevel < _engineStartThreshold)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

}