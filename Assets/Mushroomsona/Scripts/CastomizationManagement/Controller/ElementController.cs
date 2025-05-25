using System.Collections.Generic;
using UnityEngine;


public class ElementController : MonoBehaviour
{
    public ElementModel ElementModel { get; private set; }
    
    [SerializeField] private GameObject _elementPrefab;
    [SerializeField] private GameObject _uiElement;
    [SerializeField] private List<SceneCategoryData> _sceneCategories;
    
    private Transform _elementCase;
    private ElementView _elementView;

    
    private void Start()
    {
        _elementCase = GameObject.Find("SceneElements")?.transform;
        
        _elementView = new ElementView(_elementPrefab, _elementCase);
    }

    
    public void OnElementButtonClicked()
    {
        if (ElementModel == null)
            ElementModel = new ElementModel(_sceneCategories, _uiElement);

        if (_elementView.PoolElement != null && _elementView.PoolElement.activeSelf && 
            !ElementModel.CategoryData.isCategoryInvulnerable)
        {
            _elementView.PoolElement.SetActive(false);
        }
        else
        {
            _elementView.InitializeElement(ElementModel.ElementData, ElementModel.CategoryData);
        }
    }
}
