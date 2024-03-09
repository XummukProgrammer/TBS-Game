using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "TBS/Core/Settings", order = 2)]
public class TBSSettingsData : ScriptableObject
{
    [SerializeField] private TBSMapData _mapData;
    [SerializeField] private TBSResourcesData _resourcesData;

    public TBSMapData MapData => _mapData;
    public TBSResourcesData ResourcesData => _resourcesData;
}
