/// <summary>
/// Engine class
/// </summary>
public class Engine
{
  /// <summary>
  /// engine ID
  /// </summary>
  private int _id;

  /// <summary>
  /// Brand of engine.
  /// </summary>
  private Brand _brand;

  /// <summary>
  /// Engine specification.
  /// </summary>
  private EngineSpecification _engineSpecification;

  /// <summary>
  /// The total mileage of the engine.
  /// </summary>
  private float _displacement;

  /// <summary>
  /// Constructor for the Engine class.
  /// </summary>
  /// <param name="brand"></param>
  /// <param name="engineSpecification"></param>
  public Engine(Brand brand, EngineSpecification engineSpecification)
  {
    _brand = brand;
    _engineSpecification = engineSpecification;
  }
  /// <summary>
  /// Starts the engine.
  /// </summary>
  public virtual void Start()
  {
    Console.WriteLine("Engine started.");
  }

  /// <summary>
  /// Stops the engine.
  /// </summary>
  public virtual void Stop()
  {
    Console.WriteLine("Engine stopped.");
  }
}