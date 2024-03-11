public class TBSBuilding
{
    // TODO: add support more resources, not one
    private TBSResourceChanger _changer;

    public TBSBuildingID ID { get; private set; }

    public TBSBuilding(TBSBuildingID id, TBSResourceChanger changer)
    {
        ID = id;
        _changer = changer;
        TBSResourcesChangers.AddChanger(_changer);
    }

    public void Destroy()
    {
        TBSResourcesChangers.RemoveChanger(_changer);
        _changer = null;
    }

    public void UpdateChangerResources(TBSResources resources)
    {
        _changer.UpdateResources(resources);
    }
}
