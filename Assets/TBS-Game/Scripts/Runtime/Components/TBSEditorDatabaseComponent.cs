using UnityEditor;
using UnityEngine;

public static class TBSEditorDatabaseComponent
{
    public static TBSProvinceData MakeProvince(TBSProvince province)
    {
        var provinceData = ScriptableObject.CreateInstance<TBSProvinceData>();
        provinceData.Init(province.ID, province.Type);

        AssetDatabase.CreateAsset(provinceData, $"Assets/TBS-Game/Data/Provincies/Data/{province.ID}.asset");
        AssetDatabase.SaveAssets();

        return provinceData;
    }

    public static void AddProvinceInProvincies(TBSProvinceData province)
    {
        TBSContextComponent.ProvinciesData.AddProvice(province);
        EditorUtility.SetDirty(TBSContextComponent.ProvinciesData);

        AssetDatabase.SaveAssets();
    }
}
