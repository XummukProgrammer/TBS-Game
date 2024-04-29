using System.Collections.Generic;

public static class TBSCountries
{
    private static List<TBSCountry> _countries = new();

    public static List<TBSCountry>.Enumerator Countries => _countries.GetEnumerator();

    public static void Init(TBSSettingsData settingsData)
    {
        var countries = settingsData.CountriesData.Countries;
        while (countries.MoveNext())
        {
            var newCountry = new TBSCountry(countries.Current, settingsData);
            newCountry.UpdateRegions();

            _countries.Add(newCountry);
        }
    }

    public static TBSCountry GetCountry(TBSCountryID id)
    {
        foreach (var country in _countries)
        {
            if (country.Data.ID == id)
            {
                return country;
            }
        }
        return null;
    }
}
