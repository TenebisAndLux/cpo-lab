/// <summary>
/// Internal combustion engine class
/// </summary>
public class InternalCombustionEngine : Engine
{
  /// <summary>
  /// Number of cylinders in the engine.
  /// </summary>
  public int Сylinders { get; protected set; }

  /// <summary>
  /// Type of fuel used by the engine.
  /// </summary>
  private FuelType _fuelType;

  /// <summary>
  /// Ignition type of the engine.
  /// </summary>
  private IgnitionType _ignitionType;

  /// <summary>
  /// Constructor for the InternalCombustionEngine class.
  /// </summary>
  /// <param name="brand"></param>
  /// <param name="engineSpecification"></param>
  /// <param name="cylinders"></param>
  /// <param name="fuelType"></param>
  /// <param name="ignitionType"></param>
  public InternalCombustionEngine(Brand brand, EngineSpecification engineSpecification, int cylinders, FuelType fuelType, IgnitionType ignitionType)
  : base(brand, engineSpecification)
  {
    Сylinders = cylinders;
    _fuelType = fuelType;
    _ignitionType = ignitionType;
  }

  /// <summary>
  /// Activates the turbocharger to increase engine performance.
  /// </summary>
  public void ActivateTurbocharger()
  {
    if (_fuelType == FuelType.Gasoline && Сylinders > 4)
    {
      Console.WriteLine("Turbocharger activated for increased performance");
    }
    else
    {
      Console.WriteLine("Turbocharger can only be activated for gasoline engines with more than 4 cylinders");
    }
  }
  /// <summary>
  /// Initiates the combustion process in the engine.
  /// </summary>
  public void Combust()
  {
    Console.WriteLine("Combustion process initiated.");
  }
}