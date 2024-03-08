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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray MyRay;
            RaycastHit hit;
            MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(MyRay, out hit, 100))
            {
                if (hit.collider.TryGetComponent(out TBSHexagonBehaviour hexagonBehaviour))
                {
                    var hexagon = TBSMap.GetHexagonByID(hexagonBehaviour.ID);
                    if (hexagon != null)
                    {
                        var around = hexagon.AroundHexagons.Horizontal;
                        foreach (var hex in around)
                        {
                            hex.SetSelect(true);
                        }
                    }
                }
            }
        }
    }
}
