using UnityEngine;

[CreateAssetMenu(fileName = "Changer", menuName = "TBS/Resources/Changer/Changer", order = 1)]
public class TBSResourceChangerAsset : ScriptableObject
{
    [SerializeField] private TBSResourceID _id;
    [SerializeField] private int _value;
    [SerializeField] private TBSResourceChangeReason _reason;

    public TBSResourceChanger MakeChanger()
    {
        return new TBSResourceChanger(_id, _value, _reason);
    }    
}
