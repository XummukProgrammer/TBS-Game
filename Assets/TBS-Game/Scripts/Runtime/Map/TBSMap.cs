using System.Collections.Generic;
using UnityEngine;

public static class TBSMap
{
    private static TBSMapBehaviour _behaviour;
    private static TBSMapData _data;
    private static List<List<TBSHexagon>> _hexagons = new(); // TODO: use the list of the hexagons?

    public static List<TBSHexagon> Hexagons => GetHexagons();

    public static void Init(TBSMapBehaviour behaviour, TBSMapData data)
    {
        _behaviour = behaviour;
        _data = data;
    }

    public static void GenerateHexagons()
    {
        if (_data == null || _behaviour == null)
        {
            return;
        }

        int uniqueHexagonID = 0;

        for (int cellX = 0; cellX < _data.Width; cellX++)
        {
            bool isEvenX = ((float)cellX % 2) == 0;
            int elementsInCell = isEvenX ? _data.Height : _data.Height - 1;

            for (int cellY = 0; cellY < elementsInCell; cellY++)
            {
                CreateHexagon(uniqueHexagonID, cellX, cellY, isEvenX, _data.HexagonSize, _data.HexagonXOffset, _data.HexagonYOffset);
                uniqueHexagonID++;
            }
        }
    }

    public static void MakeHexagonsVisual(TBSProvinciesData provinciesData)
    {
        for (int y = 0; y < _hexagons.Count; y++)
        {
            for (int x = 0; x < _hexagons[y].Count; x++)
            {
                var province = TBSProvincies.GetProvince(_hexagons[y][x].ID);
                if (province != null)
                {
                    var visual = provinciesData.GetVisual(province.Type);
                    if (visual != null)
                    {
                        _hexagons[y][x].Instantiate(visual.Prefab, _behaviour);
                        Debug.Log($"Make a visual for a hexagon: ID: {province.ID}, Type: {province.Type}");
                    }
                }
            }
        }
    }

    public static void UpdateHexagonVisual(TBSProvince province)
    {
        var visual = TBSContextComponent.ProvinciesData.GetVisual(province.Type);
        if (visual != null)
        {
            var hexagon = GetHexagonByID(province.ID);
            if (hexagon != null)
            {
                hexagon.Reinstantiate(visual.Prefab, _behaviour);
            }
        }
    }

    public static void InitHexagons()
    {
        for (int y = 0; y < _hexagons.Count; y++)
        {
            for (int x = 0; x < _hexagons[y].Count; x++)
            {
                bool isEvenX = ((float)x % 2) == 0;

                var top = GetHexagonByCellPosition(x, y - 1);
                var down = GetHexagonByCellPosition(x, y + 1);
                var leftUpper = GetHexagonByCellPosition(x - 1, y - (isEvenX ? 1 : 0));
                var leftLower = GetHexagonByCellPosition(x - 1, y + (isEvenX ? 0 : 1));
                var rightUpper = GetHexagonByCellPosition(x + 1, y - (isEvenX ? 1 : 0));
                var rightLower = GetHexagonByCellPosition(x + 1, y + (isEvenX ? 0 : 1));
                _hexagons[y][x].SetAroundHexagons(new TBSAroundHexagons(top, down, leftUpper, leftLower, rightUpper, rightLower, isEvenX));

                Debug.Log($"[InitHexagons] The hexagon is initialized (ID: {_hexagons[y][x].ID}, AroundHexagons: {_hexagons[y][x].AroundHexagons.GetDebug()}).");
            }
        }
    }

    public static TBSHexagon GetHexagonByCellPosition(int cellX, int cellY)
    {
        if (cellY >= 0 && cellY < _hexagons.Count)
        {
            if (cellX >= 0 && cellX < _hexagons[cellY].Count)
            {
                return _hexagons[cellY][cellX];
            }
        }
        return null;
    }

    public static TBSHexagon GetHexagonByID(int id)
    {
        foreach (var yHexagons in _hexagons)
        {
            foreach (var xHexagon in yHexagons)
            {
                if (xHexagon.ID == id)
                {
                    return xHexagon;
                }
            }
        }
        return null;
    }

    public static int GetHexagonIDByCellPosition(int cellX, int cellY)
    {
        var hexagon = GetHexagonByCellPosition(cellX, cellY);
        if (hexagon != null)
        {
            return hexagon.ID;
        }
        return -1;
    }

    public static (int, int) GetHexagonCellPositionByID(int id)
    {
        for (int y = 0; y < _hexagons.Count; y++)
        {
            for (int x = 0; x < _hexagons[y].Count; x++)
            {
                if (_hexagons[y][x].ID == id)
                {
                    return (x, y);
                }
            }
        }
        return (-1, -1);
    }

    public static void ShowRelief()
    {
        for (int y = 0; y < _hexagons.Count; y++)
        {
            for (int x = 0; x < _hexagons[y].Count; x++)
            {
                _hexagons[y][x].SetMode(TBSProvinceVisualMode.Relief);
            }
        }
    }

    public static void ShowCountries()
    {
        var countriesIt = TBSCountries.Countries;
        while (countriesIt.MoveNext())
        {
            var country = countriesIt.Current;
            var regionsIt = country.Regions;
            while (regionsIt.MoveNext())
            {
                var region = regionsIt.Current;
                var provinciesIt = region.Provincies;
                while (provinciesIt.MoveNext())
                {
                    var province = provinciesIt.Current;
                    var hexagon = GetHexagonByID(province.ID); // TODO: save a hexagon in a province
                    if (hexagon != null)
                    {
                        hexagon.SetMode(TBSProvinceVisualMode.Countries);
                        hexagon.SetColor(country.Data.Color);
                    }
                }
            }
        }
    }

    private static void CreateHexagon(int id, int cellX, int cellY, bool isEvenX, int hexagonSize, float hexagonXOffset, float hexagonYOffset)
    {
        float physicsX = hexagonSize * cellX - ((cellX == 0) ? 0 : (cellX * hexagonXOffset));
        float physicsZ = hexagonSize * cellY * (-1) + (isEvenX ? hexagonYOffset : 0);

        var newHexagon = new TBSHexagon(id, physicsX, physicsZ);
        Debug.Log($"[CreateHexagon] A new Hexagon has been added (ID: {id}, CellX: {cellX}, CellY: {cellY}, PhysicsX: {physicsX}, PhysicsZ: {physicsZ}).");

        List<TBSHexagon> list = null;
        if (cellY < _hexagons.Count)
        {
            list = _hexagons[cellY];
        }
        else
        {
            list = new();
            _hexagons.Add(list);
        }

        _hexagons[cellY].Add(newHexagon);
    }

    private static List<TBSHexagon> GetHexagons()
    {
        var list = new List<TBSHexagon>();

        foreach (var yHexagons in _hexagons)
        {
            foreach (var xHexagon in yHexagons)
            {
                list.Add(xHexagon);
            }
        }

        return list;
    }
}
