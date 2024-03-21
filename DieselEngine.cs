/// <summary>
/// Diesel engine class
/// </summary>
public class DieselEngine : InternalCombustionEngine
{
  /// <summary>
  /// Turbo pressure of the diesel engine.
  /// </summary>
  private float _turboPressure;

  /// <summary>
  /// Maximum torque produced by the diesel engine.
  /// </summary>
  private float _maxTorque;

  /// <summary>
  /// Pressure of the injector for the diesel engine.
  /// </summary>
  private float _injectorPressure;

  /// <summary>
  /// Constructor for the DieselEngine class.
  /// </summary>
  /// <param name="brand"></param>
  /// <param name="engineSpecification"></param>
  /// <param name="cylinders"></param>
  /// <param name="fuelType"></param>
  /// <param name="ignitionType"></param>
  /// <param name="injectorPressure"></param>
  /// <param name="turboPressure"></param>
  public DieselEngine(Brand brand, EngineSpecification engineSpecification, int cylinders, FuelType fuelType, IgnitionType ignitionType,
  float injectorPressure, float turboPressure)
      : base(brand, engineSpecification, cylinders, fuelType, ignitionType)
  {
    _injectorPressure = injectorPressure;
    _turboPressure = turboPressure;
    _maxTorque = CalculateMaxTorque();
  }

  /// <summary>
  /// Increases the turbo pressure of the diesel engine by the specified amount.
  /// </summary>
  /// <param name="amount"></param>
  public void IncreaseTurboPressure(float amount)
  {
    _turboPressure += amount;
    Console.WriteLine($"Turbo pressure increased by {amount}.");
  }

  /// <summary>
  /// Calculate the maximum torque produced by the diesel engine.
  /// </summary>
  /// <returns> _maxTorque </returns>
  public float CalculateMaxTorque()
  {
    _maxTorque = _injectorPressure * _turboPressure * Сylinders;
    return _maxTorque;
  }

  /// <summary>
  /// Adjusts the injector pressure of the diesel engine to the specified value.
  /// </summary>
  /// <param name="amount"></param>
  public void AdjustInjectorPressure(float amount)
  {
    _injectorPressure = amount;
    Console.WriteLine($"Injector pressure adjusted to {amount}.");
  }
}