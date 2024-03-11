using System.Collections.Generic;
using UnityEngine;

public static class TBSProvincies
{
    private static List<TBSProvince> _provincies = new();

    public static void Init(TBSBuildingManagerData buildingManagerData)
    {
        var hexagons = TBSMap.Hexagons;
        foreach (var hexagon in hexagons)
        {
            AddProvince(new TBSProvince(hexagon.ID, buildingManagerData));
            Debug.Log($"A province has been added (ID: {hexagon.ID})");
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
