namespace IX.DataSets.Geographic;

public readonly record struct GeographicCodedEntity(string Name, string TwoLetterCode, string ThreeLetterCode, string NumericCode, bool IsRecognizedByUnitedNations, bool IsIndependent, bool IsUserDefined, bool IsSpecialPurposeCode);