using UnityEngine;

public class TBSLinksBehaviour : MonoBehaviour
{
    [SerializeField] private TBSMapBehaviour _mapBehaviour;

    public TBSMapBehaviour MapBehaviour => _mapBehaviour;
}
