using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "TBS/Resources/Resources", order = 1)]
public class TBSResourcesData : ScriptableObject
{
    [SerializeField] private TBSResourceData[] _resources;

    public List<TBSResourceData>.Enumerator Resources => _resources.ToList().GetEnumerator();

    public TBSResourceData GetResource(TBSResourceID id)
    {
        foreach (var resource in _resources)
        {
            if (resource.ID == id)
            {
                return resource;
            }
        }
        return null;
    }
}
