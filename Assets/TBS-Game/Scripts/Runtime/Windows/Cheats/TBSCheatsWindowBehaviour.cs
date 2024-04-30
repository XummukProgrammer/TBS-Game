using UnityEngine;
using UnityEngine.UI;

public class TBSCheatsWindowBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _hexagonsText;

    [SerializeField] private Button _provinciesButton;
    [SerializeField] private Button _regionsButton;
    [SerializeField] private Button _countriesButton;
    [SerializeField] private Button _buildingsButton;
    [SerializeField] private Button _resourcesButton;

    public void SetHexagons(int count)
    {
        if (_hexagonsText != null)
        {
            _hexagonsText.text = $"Hexagons: {count}";
        }
    }

    private void OnEnable()
    {
        if (_provinciesButton != null)
        {
            _provinciesButton.onClick.AddListener(OnProvinciesClicked);
        }

        if (_regionsButton != null)
        {
            _regionsButton.onClick.AddListener(OnRegionsClicked);
        }

        if (_countriesButton != null)
        {
            _countriesButton.onClick.AddListener(OnCountriesClicked);
        }

        if (_buildingsButton != null)
        {
            _buildingsButton.onClick.AddListener(OnBuildingsClicked);
        }

        if (_resourcesButton != null)
        {
            _resourcesButton.onClick.AddListener(OnResourcesClicked);
        }
    }

    private void OnDisable()
    {
        if (_provinciesButton != null)
        {
            _provinciesButton.onClick.RemoveListener(OnProvinciesClicked);
        }

        if (_regionsButton != null)
        {
            _regionsButton.onClick.RemoveListener(OnRegionsClicked);
        }

        if (_countriesButton != null)
        {
            _countriesButton.onClick.RemoveListener(OnCountriesClicked);
        }

        if (_buildingsButton != null)
        {
            _buildingsButton.onClick.RemoveListener(OnBuildingsClicked);
        }

        if (_resourcesButton != null)
        {
            _resourcesButton.onClick.RemoveListener(OnResourcesClicked);
        }
    }

    private void OnProvinciesClicked()
    {
        TBSCheatsWindow.OnProvinciesClicked();
    }

    private void OnRegionsClicked()
    {
        TBSCheatsWindow.OnRegionsClicked();
    }

    private void OnCountriesClicked()
    {
        TBSCheatsWindow.OnCountriesClicked();
    }

    private void OnBuildingsClicked()
    {
        TBSCheatsWindow.OnBuildingsClicked();
    }

    private void OnResourcesClicked()
    {
        TBSCheatsWindow.OnResourcesClicked();
    }
}
