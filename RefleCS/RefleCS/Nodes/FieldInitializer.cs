namespace RefleCS.Nodes;

/// <summary>
/// Represents an inline field initializer.
/// </summary>
/// <param name="Value">The full field initializer value. Must not contain the '='</param>
public record FieldInitializer(string Value);