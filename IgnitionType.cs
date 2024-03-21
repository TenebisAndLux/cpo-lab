/// <summary>
/// There are engines with self-ignition, forced ignition and combined ignition.
/// </summary>
public enum IgnitionType
{
  /// <summary>
  /// Diesels in which the fuel injected into the combustion chamber will self-ignite due to the high air temperature at the end of compression.
  /// </summary>
  SelfIgnition,

  /// <summary>
  /// All carburetor and gas engines in which ignition occurs from an external source (electric spark).
  /// </summary>
  ForcedIgnition,
  /// <summary>
  /// Gas diesels in which the working mixture is forcibly ignited by self-ignition of liquid ignition fuel.
  /// </summary>
  CombinedIgnition
}