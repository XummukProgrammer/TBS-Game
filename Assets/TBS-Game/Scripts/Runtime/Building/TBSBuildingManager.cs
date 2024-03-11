using System.Collections.Generic;

public class TBSBuildingManager
{
    private List<TBSBuilding> _building = new();
    private TBSBuildingManagerData _data;

    public void Init(TBSBuildingManagerData data)
    {
        _data = data;
    }

    public void AddBuilding(TBSBuildingID id)
    {
        var buildingData = _data.GetBuildingData(id);
        if (buildingData != null)
        {
            var newBuilding = new TBSBuilding(id, buildingData.MakeResourceChanger());
            _building.Add(newBuilding);
        }
    }

    public void RemoveBuilding(TBSBuildingID id)
    {
        foreach (var building in _building)
        {
            if (building.ID == id)
            {
                building.Destroy();
                _building.Remove(building);
            }
        }
    }

    public void UpdateResources(TBSResources resources)
    {
        foreach (var building in _building)
        {
            building.UpdateChangerResources(resources);
        }
    }
}
