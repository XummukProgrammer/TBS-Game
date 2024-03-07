using UnityEngine;

[CreateAssetMenu(fileName = "Boostrap", menuName = "TBS/Core/Boostrap", order = 1)]
public class TBSBoostrapAsset : ScriptableObject
{
    [SerializeField] private TBSSettingsData _settingsData;

    public virtual TBSBoostrap MakeBoostrap(TBSLinksBehaviour linksBehaviour) { return new TBSBoostrap(_settingsData, linksBehaviour); }
}
