namespace IX.DataSets.Geographic;

/// <summary>
/// Represents an ISO 3166-2 geographic subdivision (such as a state, province, or region) belonging to an ISO 3166-1 coded entity.
/// </summary>
/// <param name="Parent">The ISO 3166-1 alpha-2 (two-letter) code of the parent country or territory.</param>
/// <param name="Code">The ISO 3166-2 code that uniquely identifies this subdivision (e.g., "US-CA").</param>
/// <param name="Name">The English name of the subdivision.</param>
/// <param name="NativeName">The name of the subdivision in its native language. When no distinct native name exists, this is the same as <paramref name="Name"/>.</param>
/// <param name="Category">The category or type of the subdivision (e.g., "State", "Province", "Region"). Defaults to "Subdivision" when no category is defined.</param>
public readonly record struct GeographicEntitySubdivision(string Parent, string Code, string Name, string NativeName, string Category);
