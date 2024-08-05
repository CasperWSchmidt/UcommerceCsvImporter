namespace UcommerceCsvImporter.Exceptions;

/// <summary>
/// Exception thrown when a configuration section is missing from the settings.
/// </summary>
/// <param name="message">Details of what section is missing</param>
public class ConfigurationException(string message) : Exception(message);