public class TBSBuilding
{
    // TODO: add support more resources, not one
    private TBSResourceChanger _changer;

    public TBSBuilding(TBSResourceChanger changer)
    {
        _changer = changer;
        TBSResourcesChangers.AddChanger(_changer);
    }

    public void Destroy()
    {
        TBSResourcesChangers.RemoveChanger(_changer);
        _changer = null;
    }
}
