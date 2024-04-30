using System;
using UnityEngine;
using UnityEngine.UI;

public enum TBSProvinceCheatWindowTransformType
{
    Update,
    Create
}

public class TBSProvinceCheatWindowBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _idText;
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _updateButton;
    [SerializeField] private TMPro.TMP_Dropdown _typeDropdown;

    [SerializeField] private Transform _updateTransform;
    [SerializeField] private Transform _createTransform;

    public string ProvinceType => GetProvinceType();

    public void SetID(int id)
    {
        if (_idText != null)
        {
            _idText.text = $"ID: {id}";
        }
    }

    public void InitTypeDropdown(string currType, string[] types)
    {
        if (_typeDropdown != null)
        {
            _typeDropdown.ClearOptions();

            int index = 0;
            foreach (var type in types)
            {
                _typeDropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(type));
                
                if (type == currType)
                {
                    _typeDropdown.value = index;
                }
                
                ++index;
            }
        }
    }

    public void SetTransform(TBSProvinceCheatWindowTransformType type)
    {
        _updateTransform.gameObject.SetActive(false);
        _createTransform.gameObject.SetActive(false);

        switch (type)
        {
            case TBSProvinceCheatWindowTransformType.Update:
                _updateTransform.gameObject.SetActive(true);
                break;

            case TBSProvinceCheatWindowTransformType.Create:
                _createTransform.gameObject.SetActive(true);
                break;
        }
    }

    private void OnEnable()
    {
        if (_createButton != null)
        {
            _createButton.onClick.AddListener(OnCreateClicked);
        }   

        if (_updateButton != null)
        {
            _updateButton.onClick.AddListener(OnUpdateClicked);
        }
    }

    private void OnDisable()
    {
        if (_createButton != null)
        {
            _createButton.onClick.RemoveListener(OnCreateClicked);
        }

        if (_updateButton != null)
        {
            _updateButton.onClick.RemoveListener(OnUpdateClicked);
        }
    }

    private void OnCreateClicked()
    {
        TBSProvinceCheatWindow.OnCreateClicked();
    }

    private void OnUpdateClicked()
    {
        TBSProvinceCheatWindow.OnUpdateClicked();
    }

    private string GetProvinceType()
    {
        if (_typeDropdown != null)
        {
            return _typeDropdown.options[_typeDropdown.value].text;
        }
        return null;
    }
}
