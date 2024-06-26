using System.Collections.Generic;
using UnityEngine;

public class TBSAroundHexagons
{
    public TBSHexagon Top { get; private set; }
    public TBSHexagon Down { get; private set; }
    public TBSHexagon LeftUpper { get; private set; }
    public TBSHexagon LeftLower { get; private set; }
    public TBSHexagon RightUpper { get; private set; }
    public TBSHexagon RightLower { get; private set; }
    public bool IsEven { get; private set; }

    public List<TBSHexagon> Around => GetAround();
    public List<TBSHexagon> Horizontal => GetHorizontal();
    public List<TBSHexagon> Vertical => GetVertical();
    public List<TBSHexagon> LeftDiagonal => GetLeftDiagonal();
    public List<TBSHexagon> RightDiagonal => GetRightDiagonal();

    public TBSAroundHexagons(TBSHexagon top, TBSHexagon down, TBSHexagon leftUpper, TBSHexagon leftLower, TBSHexagon rightUpper, TBSHexagon rightLower, bool isEven)
    {
        Top = top;
        Down = down;
        LeftUpper = leftUpper;
        LeftLower = leftLower;
        RightUpper = rightUpper;
        RightLower = rightLower;
        IsEven = isEven;
    }

    public TBSHexagon GetHexagonByXY(float x, float y)
    {
        if (x == 0 && y == 0)
        {
            return null;
        }
        if (x == 0 && y == -1)
        {
            return Top;
        }
        if (x == 0 && y == 1)
        {
            return Down;
        }
        if (x == -1 && y == -1)
        {
            return LeftUpper;
        }
        if (x == -1 && y == 1)
        {
            return LeftLower;
        }
        if (x == 1 && y == -1)
        {
            return RightUpper;
        }
        if (x == 1 && y == 1)
        {
            return RightLower;
        }
        return null;
    }

    public string GetDebug()
    {
        string str = "";

        if (Top != null)
        {
            str += " Top: " + Top.ID.ToString();
        }
        if (Down != null)
        {
            str += " Down: " + Down.ID.ToString();
        }
        if (LeftUpper != null)
        {
            str += " LeftUpper: " + LeftUpper.ID.ToString();
        }
        if (LeftLower != null)
        {
            str += " LeftLower: " + LeftLower.ID.ToString();
        }
        if (RightUpper != null)
        {
            str += " RightUpper: " + RightUpper.ID.ToString();
        }
        if (RightLower != null)
        {
            str += " RightLower: " + RightLower.ID.ToString();
        }

        return str;
    }

    private List<TBSHexagon> GetAround()
    {
        var list = new List<TBSHexagon>();

        if (Top != null)
        {
            list.Add(Top);
        }
        if (RightUpper != null)
        {
            list.Add(RightUpper);
        }
        if (RightLower != null)
        {
            list.Add(RightLower);
        }
        if (Down != null)
        {
            list.Add(Down);
        }
        if (LeftLower != null)
        {
            list.Add(LeftLower);
        }
        if (LeftUpper != null)
        {
            list.Add(LeftUpper);
        }
        
        return list;
    }

    private List<TBSHexagon> GetHorizontal()
    {
        var list = new List<TBSHexagon>();

        var hexagon = IsEven ? RightUpper : RightLower;
        while (hexagon != null)
        {
            list.Add(hexagon);
            hexagon = hexagon.AroundHexagons.IsEven ? hexagon.AroundHexagons.RightUpper : hexagon.AroundHexagons.RightLower;
        }

        hexagon = IsEven ? LeftUpper : LeftLower;
        while (hexagon != null)
        {
            list.Add(hexagon);
            hexagon = hexagon.AroundHexagons.IsEven ? hexagon.AroundHexagons.LeftUpper : hexagon.AroundHexagons.LeftLower;
        }

        return list;
    }

    private List<TBSHexagon> GetVertical()
    {
        return GetLineByXY(0, -1, 0, 1);
    }

    private List<TBSHexagon> GetLeftDiagonal()
    {
        return GetLineByXY(-1, -1, 1, 1);
    }

    private List<TBSHexagon> GetRightDiagonal()
    {
        return GetLineByXY(1, -1, -1, 1);
    }

    private List<TBSHexagon> GetLineByXY(float xForFirstDirection, float yForFirstDirection, float xForSecondDirection, float yForSecondDirection)
    {
        var list = new List<TBSHexagon>();

        var hexagon = GetHexagonByXY(xForFirstDirection, yForFirstDirection);
        while (hexagon != null)
        {
            list.Add(hexagon);
            hexagon = hexagon.AroundHexagons.GetHexagonByXY(xForFirstDirection, yForFirstDirection);
        }

        hexagon = GetHexagonByXY(xForSecondDirection, yForSecondDirection);
        while (hexagon != null)
        {
            list.Add(hexagon);
            hexagon = hexagon.AroundHexagons.GetHexagonByXY(xForSecondDirection, yForSecondDirection);
        }

        return list;
    }
}

public class TBSHexagon
{
    private float _physicsX;
    private float _physicsZ;

    public int ID { get; private set; }
    public TBSHexagonBehaviour Behaviour { get; private set; }
    public TBSAroundHexagons AroundHexagons { get; private set; }

    public TBSHexagon(int id, float physicsX, float physicsZ)
    {
        ID = id;
        _physicsX = physicsX;
        _physicsZ = physicsZ;
    }

    public void SetAroundHexagons(TBSAroundHexagons aroundHexagons)
    {
        AroundHexagons = aroundHexagons;
    }

    public void SetSelect(bool isSelect)
    {
        Behaviour.SetSelect(isSelect);
    }

    public void Instantiate(TBSHexagonBehaviour prefab, TBSMapBehaviour mapBehaviour)
    {
        Behaviour = mapBehaviour.MakeHexagon(prefab);
        Behaviour.Init(ID, _physicsX, _physicsZ);
    }

    public void Reinstantiate(TBSHexagonBehaviour prefab, TBSMapBehaviour mapBehaviour)
    {
        GameObject.Destroy(Behaviour.gameObject);
        Instantiate(prefab, mapBehaviour);
    }

    public void SetMode(TBSProvinceVisualMode mode)
    {
        Behaviour.SetMode(mode);
    }

    public void SetColor(Color color)
    {
        Behaviour.SetColor(color);
    }
}
