using System.Collections.Generic;
using UnityEngine;

public static class TBSMap
{
    private static TBSMapBehaviour _behaviour;
    private static TBSMapData _data;
    private static List<List<TBSHexagon>> _hexagons = new(); // TODO: use the list of the hexagons?

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

    public static TBSHexagon GetHexagonByCellPosition(int cellX, int cellY)
    {
        if (cellY < _hexagons.Count)
        {
            if (cellX < _hexagons[cellY].Count)
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

    private static void CreateHexagon(int id, int cellX, int cellY, bool isEvenX, int hexagonSize, float hexagonXOffset, float hexagonYOffset)
    {
        var newHexagonData = GetHexagonData(id);
        if (newHexagonData == null)
        {
            return;
        }

        var newHexagonBehaviour = _behaviour.MakeHexagon(newHexagonData.Prefab);
        if (newHexagonBehaviour == null)
        {
            return;
        }

        float physicsX = hexagonSize * cellX - ((cellX == 0) ? 0 : (cellX * hexagonXOffset));
        float physicsZ = hexagonSize * cellY * (-1) + (isEvenX ? hexagonYOffset : 0);

        newHexagonBehaviour.Init(physicsX, physicsZ);

        var newHexagon = new TBSHexagon(id, newHexagonBehaviour, newHexagonData);
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

    private static TBSHexagonData GetHexagonData(int id)
    {
        if (_data == null)
        {
            return null;
        }

        var hexagons = _data.Hexagons;
        while (hexagons.MoveNext())
        {
            if (hexagons.Current.ID == id)
            {
                return hexagons.Current;
            }
        }

        return _data.DefaultHexagon;
    }
}
