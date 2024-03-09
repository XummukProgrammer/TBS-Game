using System.Collections.Generic;
using UnityEngine;

public class TBSResources
{
    private List<TBSResource> _resources = new();

    public void InitResources(TBSResourcesData data)
    {
        var resources = data.Resources;
        while (resources.MoveNext())
        {
            var resourceData = resources.Current;
            var resource = new TBSResource(resourceData, 0);
            _resources.Add(resource);

            Debug.Log($"Added resource: {resource.GetDebug()}");
        }
    }

    public TBSResource GetResource(TBSResourceID id)
    {
        foreach (var resource in _resources)
        {
            if (resource.Data.ID == id)
            {
                return resource;
            }
        }
        return null;
    }

    public void GiveResourceValue(TBSResourceID id, int value)
    {
        var resource = GetResource(id);
        if (resource != null)
        {
            resource.GiveValue(value);
        }
    }

    public void TakeResourceValue(TBSResourceID id, int value)
    {
        var resource = GetResource(id);
        if (resource != null)
        {
            resource.TakeValue(value);
        }
    }
}
