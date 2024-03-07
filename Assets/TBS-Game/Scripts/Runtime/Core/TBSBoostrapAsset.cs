using UnityEngine;

[CreateAssetMenu(fileName = "Boostrap", menuName = "TBS/Core/Boostrap", order = 1)]
public class TBSBoostrapAsset : ScriptableObject
{
    public virtual TBSBoostrap MakeBoostrap() { return new TBSBoostrap(); }
}
