using System.Collections.Generic;

public static class TBSCountries
{
    private static List<TBSCountry> _countries = new();

    public static void Init(TBSSettingsData settingsData)
    {
        var countries = settingsData.CountriesData.Countries;
        while (countries.MoveNext())
        {
            _countries.Add(new TBSCountry(countries.Current, settingsData));
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
