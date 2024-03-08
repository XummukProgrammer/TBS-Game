using UnityEngine;

public class TBSHexagonBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _selectTransform;

    public int ID { get; private set; }

    public void Init(int id, float x, float z)
    {
        ID = id;
        transform.position = new Vector3(x, 0, z);
    }

    public void SetSelect(bool isSelect)
    {
        if (_selectTransform != null)
        {
            _selectTransform.gameObject.SetActive(isSelect);
        }
    }
}
