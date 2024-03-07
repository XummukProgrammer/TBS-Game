using UnityEngine;

public class TBSHexagonBehaviour : MonoBehaviour
{
    public void Init(float x, float z)
    {
        transform.position = new Vector3(x, 0, z);
    }
}
