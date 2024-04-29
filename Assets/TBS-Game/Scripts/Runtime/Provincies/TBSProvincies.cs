using System.Collections.Generic;
using UnityEngine;

public static class TBSProvincies
{
    private static List<TBSProvince> _provincies = new();

    public static void Init(TBSProvinciesData provinciesData, TBSBuildingManagerData buildingManagerData)
    {
        var hexagons = TBSMap.Hexagons;
        foreach (var hexagon in hexagons)
        {
            var province = new TBSProvince(hexagon.ID, buildingManagerData);
            AddProvince(province);
            Debug.Log($"A province has been added (ID: {hexagon.ID})");
        }

        var provinciesIt = provinciesData.Provincies;
        while (provinciesIt.MoveNext())
        {
            var province = GetProvince(provinciesIt.Current.ID);
            if (province != null)
            {
                province.PostInit(provinciesIt.Current);
            }
        }
    }

    public static void AddProvince(TBSProvince province)
    {
        _provincies.Add(province);
    }

    public static void RemoveProvince(TBSProvince province)
    {
        _provincies.Remove(province);
    }

    public static TBSProvince GetProvince(int id)
    {
        foreach (var province in _provincies)
        {
            if (province.ID == id)
            {
                return province;
            }
        }
        return null;
    }
}
