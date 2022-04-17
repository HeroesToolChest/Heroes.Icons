namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides the basic properties for a data document.
/// </summary>
public interface IDataDocument
{
    /// <summary>
    /// Gets a collection of all ids (the root element property values).
    /// </summary>
    IEnumerable<string> GetIds { get; }

    /// <summary>
    /// Gets a collection of all name property values.
    /// </summary>
    IEnumerable<string> GetNames { get; }

    /// <summary>
    /// Gets a collection of all hyperlinkId property values.
    /// </summary>
    IEnumerable<string> GetHyperlinkIds { get; }

    /// <summary>
    /// Gets the amount of total items.
    /// </summary>
    int Count { get; }
}
