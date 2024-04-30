public enum TBSCheatsWindowMode
{
    Default,

    Provincies,
    Regions,
    Countries,
    Buildings,
    Resources
}

public static class TBSCheatsWindow
{
    private static TBSCheatsWindowBehaviour _behaviour;
    private static bool _isEnabled;
    private static TBSCheatsWindowMode _mode;

    public static void Init(TBSCheatsWindowBehaviour behaviour)
    {
        _behaviour = behaviour;
        _isEnabled = false;
        _mode = TBSCheatsWindowMode.Default;
    }

    public static void Enable()
    {
        if (_behaviour != null)
        {
            _behaviour.gameObject.SetActive(true);
            _isEnabled = true;
            _mode = TBSCheatsWindowMode.Default;

            _behaviour.SetHexagons(TBSMap.Hexagons.Count);
        }
    }

    public static void Disable()
    {
        if (_behaviour != null)
        {
            _behaviour.gameObject.SetActive(false);
            _isEnabled = false;
        }
    }

    public static void Toggle()
    {
        if (_isEnabled)
        {
            Disable();
        }
        else
        {
            Enable();
        }
    }

    public static void OnProvinciesClicked()
    {
        _mode = TBSCheatsWindowMode.Provincies;

        TBSContextComponent.SelectedHexagon = null;
    }

    public static void OnRegionsClicked()
    {
        _mode = TBSCheatsWindowMode.Regions;
    }

    public static void OnCountriesClicked()
    {
        _mode = TBSCheatsWindowMode.Countries;
    }

    public static void OnBuildingsClicked()
    {
        _mode = TBSCheatsWindowMode.Buildings;
    }

    public static void OnResourcesClicked()
    {
        _mode = TBSCheatsWindowMode.Resources;
    }

    public static void OnUpdate()
    {
        switch (_mode)
        {
            case TBSCheatsWindowMode.Provincies:
                OnProvinciesProcess();
                break;

            case TBSCheatsWindowMode.Regions:
                OnRegionsProcess();
                break;

            case TBSCheatsWindowMode.Countries:
                OnCountriesProcess();
                break;

            case TBSCheatsWindowMode.Buildings:
                OnBuildingsProcess();
                break;

            case TBSCheatsWindowMode.Resources:
                OnResourcesProcess();
                break;
        }
    }

    private static void OnProvinciesProcess()
    {
        if (TBSContextComponent.SelectedHexagon != null)
        {
            TBSProvinceCheatWindow.SetHexagon(TBSContextComponent.SelectedHexagon);
            TBSProvinceCheatWindow.Enable();

            TBSContextComponent.SelectedHexagon = null;
        }
    }

    private static void OnRegionsProcess()
    {
    }

    private static void OnCountriesProcess()
    {
    }

    private static void OnBuildingsProcess()
    {
    }

    private static void OnResourcesProcess()
    {
    }
}
