using System.Diagnostics.CodeAnalysis;

namespace IX.DataSets.Geographic;

public partial class GeographicService : IGeographicService
{
    private static Lazy<Dictionary<ReadOnlyMemory<char>, GeographicCodedEntity>> _countriesByTwoLetterCode =>
        new(() => _countries.Value.ToDictionary(c => c.TwoLetterCode.AsMemory()));

    private static Lazy<Dictionary<ReadOnlyMemory<char>, GeographicCodedEntity>> _countriesByThreeLetterCode =>
        new(() => _countries.Value.ToDictionary(c => c.ThreeLetterCode.AsMemory()));

    private static Lazy<Dictionary<ReadOnlyMemory<char>, GeographicCodedEntity>> _countriesByNumericCode =>
        new(() => _countries.Value.ToDictionary(c => c.NumericCode.AsMemory()));

    public GeographicCodedEntity[] GetCountries()
    {
        return _countries.Value;
    }

    public bool TryGetCountry(in ReadOnlyMemory<char> nameOrCode,
        [NotNullWhen(true)] out GeographicCodedEntity? country, bool exactMatchOnly = false, bool ignoreCase = true)
    {
        var codeToFind = ignoreCase ? nameOrCode.ToString().ToUpper().AsMemory() : nameOrCode;

        if (_countriesByTwoLetterCode.Value.TryGetValue(codeToFind, out var found))
        {
            // Exact match on two-letter code
            country = found;
            return true;
        }

        if (_countriesByThreeLetterCode.Value.TryGetValue(codeToFind, out found))
        {
            // Exact match on three-letter code
            country = found;
            return true;
        }

        if (_countriesByNumericCode.Value.TryGetValue(codeToFind, out found))
        {
            // Exact match on numeric code
            country = found;
            return true;
        }

        if (exactMatchOnly)
        {
            // No exact match found, and we're only looking for exact matches
            country = null;
            return false;
        }

        if (_countriesByTwoLetterCode.Value.Values.Any(c =>
                c.TwoLetterCode.Contains(codeToFind.Span, StringComparison.Ordinal)))
        {
            // Partial match on two-letter code
            country = found;
            return true;
        }

        if (_countriesByThreeLetterCode.Value.Values.Any(c =>
                c.ThreeLetterCode.Contains(codeToFind.Span, StringComparison.Ordinal)))
        {
            // Partial match on three-letter code
            country = found;
            return true;
        }

        if (_countriesByNumericCode.Value.Values.Any(c =>
                c.NumericCode.Contains(codeToFind.Span, StringComparison.Ordinal)))
        {
            // Partial match on numeric code
            country = found;
            return true;
        }

        // No match, even partial
        country = null;
        return false;
    }
}