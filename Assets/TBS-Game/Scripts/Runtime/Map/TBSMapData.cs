using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "TBS/Map/Map", order = 1)]
public class TBSMapData : ScriptableObject
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private int _hexagonSize;
    [SerializeField] private float _hexagonXOffset;
    [SerializeField] private float _hexagonYOffset;

    public int Width => _width;
    public int Height => _height;
    public int HexagonSize => _hexagonSize;
    public float HexagonXOffset => _hexagonXOffset;
    public float HexagonYOffset => _hexagonYOffset;
}
