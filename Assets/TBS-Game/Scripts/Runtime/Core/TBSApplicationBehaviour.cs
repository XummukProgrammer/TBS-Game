using UnityEngine;

public class TBSApplicationBehaviour : MonoBehaviour
{
    [SerializeField] private TBSBoostrapAsset _boostrapAsset;

    private TBSBoostrap _boostrap;

    private void Awake()
    {
        if (_boostrapAsset == null)
        {
            return;
        }

        _boostrap = _boostrapAsset.MakeBoostrap();
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
