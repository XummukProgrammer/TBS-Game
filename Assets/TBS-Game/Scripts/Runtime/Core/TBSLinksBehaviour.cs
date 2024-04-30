using UnityEngine;

public class TBSLinksBehaviour : MonoBehaviour
{
    [SerializeField] private TBSMapBehaviour _mapBehaviour;

    [SerializeField] private TBSCheatsWindowBehaviour _cheatsWindowBehaviour;
    [SerializeField] private TBSProvinceCheatWindowBehaviour _provinceCheatWindowBehaviour;

    public TBSMapBehaviour MapBehaviour => _mapBehaviour;

    public TBSCheatsWindowBehaviour CheatsWindowBehaviour => _cheatsWindowBehaviour;
    public TBSProvinceCheatWindowBehaviour ProvinceCheatWindowBehaviour => _provinceCheatWindowBehaviour;
}
