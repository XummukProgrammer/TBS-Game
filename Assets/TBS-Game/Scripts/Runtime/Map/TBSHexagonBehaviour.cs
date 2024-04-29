using System.Linq;
using UnityEngine;

[System.Serializable]
public class TBSHexagonModeTransform
{
    [SerializeField] private TBSProvinceVisualMode _mode;
    [SerializeField] private MeshRenderer _meshRenderer;

    public TBSProvinceVisualMode Mode => _mode;
    public MeshRenderer MeshRenderer => _meshRenderer;
}

public class TBSHexagonBehaviour : MonoBehaviour
{
    [SerializeField] private TBSHexagonModeTransform[] _modeTransforms;

    [SerializeField] private Transform _selectTransform;

    private MeshRenderer _activeModeMeshRenderer;

    public int ID { get; private set; }

    public void Init(int id, float x, float z)
    {
        ID = id;
        transform.position = new Vector3(x, 0, z);

        SetMode(TBSProvinceVisualMode.Relief);
    }

    public void SetMode(TBSProvinceVisualMode mode)
    {
        if (_activeModeMeshRenderer != null)
        {
            _activeModeMeshRenderer.gameObject.SetActive(false);
        }

        var modeTransform = GetModeTransform(mode);
        if (modeTransform != null)
        {
            _activeModeMeshRenderer = modeTransform.MeshRenderer;
            _activeModeMeshRenderer.gameObject.SetActive(true);
        }
    }

    public void SetColor(Color color)
    {
        if (_activeModeMeshRenderer != null)
        {
            _activeModeMeshRenderer.material.color = color;
        }
    }

    public void SetSelect(bool isSelect)
    {
        if (_selectTransform != null)
        {
            _selectTransform.gameObject.SetActive(isSelect);
        }
    }

    private TBSHexagonModeTransform GetModeTransform(TBSProvinceVisualMode mode)
    {
        return _modeTransforms.ToList().Find(modeTransform => modeTransform.Mode == mode);
    }
}
