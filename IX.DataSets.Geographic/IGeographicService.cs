using System.Diagnostics.CodeAnalysis;

namespace IX.DataSets.Geographic;

/// <summary>
/// A service contract for geographic-related services, such as retrieving information about countries, regions, etc.
/// </summary>
public interface IGeographicService
{
    GeographicCodedEntity[] GetCountries();

    bool TryGetCountry(in ReadOnlyMemory<char> nameOrCode, [NotNullWhen(true)] out GeographicCodedEntity? country,
        bool exactMatchOnly = false, bool ignoreCase = true);
}