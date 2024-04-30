public static class TBSProvinceCheatWindow
{
    private static TBSProvinceCheatWindowBehaviour _behaviour;
    private static TBSHexagon _hexagon;
    private static TBSProvince _province;

    public static void Init(TBSProvinceCheatWindowBehaviour behaviour)
    {
        _behaviour = behaviour;
    }

    public static void SetHexagon(TBSHexagon hexagon)
    {
        _hexagon = hexagon;
        _province = TBSProvincies.GetProvince(_hexagon.ID);
    }

    public static void Enable()
    {
        if (_behaviour != null)
        {
            _behaviour.gameObject.SetActive(true);

            UpdateBehaviour();
        }
    }

    public static void Disable()
    {
        if (_behaviour != null)
        {
            _behaviour.gameObject.SetActive(false);
        }
    }

    public static void OnCreateClicked()
    {
        var provinceData = TBSEditorDatabaseComponent.MakeProvince(_province);
        TBSEditorDatabaseComponent.AddProvinceInProvincies(provinceData);

        _province.PostInit(provinceData);

        UpdateBehaviour();
    }

    public static void OnUpdateClicked()
    {
        _province.Update(_behaviour.ProvinceType);
    }

    private static void UpdateBehaviour()
    {
        if (_behaviour != null)
        {
            _behaviour.SetID(_province.ID);
            _behaviour.InitTypeDropdown(_province.Type, TBSContextComponent.ProvinciesData.ProvinciesTypes.ToArray());
            _behaviour.SetTransform(_province.IsDefault ? TBSProvinceCheatWindowTransformType.Create : TBSProvinceCheatWindowTransformType.Update);
        }
    }
}
