

using UnityEditor;
using UnityEngine;

public class TBSProvince
{
    public int ID { get; private set; }
    public string Type { get; private set; }
    public bool IsDefault { get; private set; }

    public TBSBuildingManager BuildingManager { get; private set; } = new();

    public TBSProvince(int id, TBSBuildingManagerData buildingManagerData)
    {
        ID = id;

        BuildingManager.Init(buildingManagerData);
    }

    public void PostInit(TBSProvinceData data)
    {
        Type = data.Type;
        IsDefault = data.ID == -1;

        var buildingsIt = data.Buildings;
        while (buildingsIt.MoveNext())
        {
            BuildingManager.AddBuilding(buildingsIt.Current);
            Debug.Log($"Added a building: Province: {ID}, ID: {buildingsIt.Current}");
        }
    }

    public void UpdateResources(TBSResources resources)
    {
        BuildingManager.UpdateResources(resources);
    }

    public void Update(string type)
    {
        Type = type;

        var provinceData = TBSContextComponent.ProvinciesData.GetProvince(ID);
        if (provinceData != null)
        {
            provinceData.UpdateParams(Type);
            EditorUtility.SetDirty(provinceData);

            AssetDatabase.SaveAssets();
        }

        TBSMap.UpdateHexagonVisual(this);
    }
}
