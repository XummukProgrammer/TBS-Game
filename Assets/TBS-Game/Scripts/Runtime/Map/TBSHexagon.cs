public class TBSHexagon
{
    public int ID { get; private set; }
    public TBSHexagonBehaviour Behaviour { get; private set; }
    public TBSHexagonData Data { get; private set; }

    public TBSHexagon(int id, TBSHexagonBehaviour behaviour, TBSHexagonData data)
    {
        ID = id;
        Behaviour = behaviour;
        Data = data;
    }
}
