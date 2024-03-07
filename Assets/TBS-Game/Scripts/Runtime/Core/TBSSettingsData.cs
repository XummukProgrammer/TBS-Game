using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "TBS/Core/Settings", order = 2)]
public class TBSSettingsData : ScriptableObject
{
    [SerializeField] private TBSMapData _mapData;

    public TBSMapData MapData => _mapData;
}
