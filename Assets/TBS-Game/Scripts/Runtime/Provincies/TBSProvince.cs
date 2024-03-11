public class TBSProvince
{
    public int ID { get; private set; }

    public TBSBuildingManager BuildingManager { get; private set; } = new();

    public TBSProvince(int id, TBSBuildingManagerData buildingManagerData)
    {
        ID = id;

        BuildingManager.Init(buildingManagerData);
    }

    public void UpdateResources(TBSResources resources)
    {
        BuildingManager.UpdateResources(resources);
    }
}
