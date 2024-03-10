using System.Collections.Generic;

public static class TBSResourcesChangers
{
    private static List<TBSResourceChanger> _changers = new();

    public static void AddChanger(TBSResourceChanger changer)
    {
        changer.Init();
        _changers.Add(changer);
    }

    public static void RemoveChanger(TBSResourceChanger changer)
    {
        changer.Deinit();
        _changers.Remove(changer);
    }
}
