using System.Collections.Generic;

public class TBSBuildingManager
{
    private List<TBSBuilding> _building = new();
    private TBSBuildingManagerData _data;

    public void Init(TBSBuildingManagerData data)
    {
        _data = data;
    }

    public void AddBuilding(TBSBuilding building)
    {
        _building.Add(building);
    }

    public void RemoveBuilding(TBSBuilding building)
    {
        _building.Remove(building);
        building.Destroy();
    }

    public TBSBuilding MakeBuilding(TBSResources resources, TBSBuildingID id)
    {
        var buildingData = _data.GetBuildingData(id);
        if (buildingData != null)
        {
            return new TBSBuilding(buildingData.MakeResourceChanger(resources));
        }
        return null;
    }
}
