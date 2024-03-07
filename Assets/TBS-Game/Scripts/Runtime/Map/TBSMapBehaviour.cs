using UnityEngine;

public class TBSMapBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public TBSHexagonBehaviour MakeHexagon(TBSHexagonBehaviour prefab)
    {
        if (_container == null || prefab == null)
        {
            return null;
        }
        return Instantiate(prefab, _container);
    }
}
