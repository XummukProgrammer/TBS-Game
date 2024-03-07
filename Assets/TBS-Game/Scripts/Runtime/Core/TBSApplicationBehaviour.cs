using UnityEngine;

public class TBSApplicationBehaviour : MonoBehaviour
{
    [SerializeField] private TBSBoostrapAsset _boostrapAsset;
    [SerializeField] private TBSLinksBehaviour _linksBehaviour;

    private TBSBoostrap _boostrap;

    private void Awake()
    {
        if (_boostrapAsset == null)
        {
            return;
        }

        _boostrap = _boostrapAsset.MakeBoostrap(_linksBehaviour);
        if (_boostrap == null)
        {
            return;
        }

        _boostrap.Setup();
    }

    private void OnDestroy()
    {
        if (_boostrap == null)
        {
            return;
        }

        _boostrap.Destroy();
    }
}
