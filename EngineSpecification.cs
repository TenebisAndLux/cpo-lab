/// <summary>
/// Characteristics that affect the performance of the engine, or its specification.
/// </summary>
public struct EngineSpecification
{
  /// <summary>
  /// Engine Power.
  /// </summary>
  public float Power { get; private set; }

  /// <summary>
  /// The torque of the engine. The thrust that the engine gives out.
  /// </summary>
  public float Torque { get; private set; }
}