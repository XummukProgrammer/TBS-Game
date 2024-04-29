using System.Linq;
using UnityEngine;

[System.Serializable]
public class TBSHexagonModeTransform
{
    [SerializeField] private TBSProvinceVisualMode _mode;
    [SerializeField] private Transform _transform;

    public TBSProvinceVisualMode Mode => _mode;
    public Transform Transform => _transform;
}

public class TBSHexagonBehaviour : MonoBehaviour
{
    [SerializeField] private TBSHexagonModeTransform[] _modeTransforms;

    [SerializeField] private Transform _selectTransform;

    private Transform _activeModeTransform;

    public int ID { get; private set; }

    public void Init(int id, float x, float z)
    {
        ID = id;
        transform.position = new Vector3(x, 0, z);

        SetMode(TBSProvinceVisualMode.Relief);
    }

    public void SetMode(TBSProvinceVisualMode mode)
    {
        if (_activeModeTransform != null)
        {
            _activeModeTransform.gameObject.SetActive(false);
        }

        var modeTransform = GetModeTransform(mode);
        if (modeTransform != null)
        {
            _activeModeTransform = modeTransform.Transform;
            _activeModeTransform.gameObject.SetActive(true);
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
