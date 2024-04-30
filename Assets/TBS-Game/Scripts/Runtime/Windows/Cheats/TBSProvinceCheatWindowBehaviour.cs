using UnityEngine;
using UnityEngine.UI;

public class TBSProvinceCheatWindowBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _idText;
    [SerializeField] private TMPro.TMP_Text _typeText;
    [SerializeField] private Button _createButton;

    public void SetID(int id)
    {
        if (_idText != null)
        {
            _idText.text = $"ID: {id}";
        }
    }

    public void SetType(TBSProvinceType type)
    {
        if (_typeText != null)
        {
            _typeText.text = $"Type: {type}";
        }
    }

    public void SetIsEnableCreateButton(bool isEnable)
    {
        if (_createButton != null)
        {
            _createButton.gameObject.SetActive(isEnable);
        }
    }

    private void OnEnable()
    {
        if (_createButton != null)
        {
            _createButton.onClick.AddListener(OnCreateClicked);
        }   
    }

    private void OnDisable()
    {
        if (_createButton != null)
        {
            _createButton.onClick.RemoveListener(OnCreateClicked);
        }
    }

    private void OnCreateClicked()
    {
        TBSProvinceCheatWindow.OnCreateClicked();
    }
}
