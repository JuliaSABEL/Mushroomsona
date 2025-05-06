using System.Collections.Generic;
using UnityEngine;


public class ElementController : MonoBehaviour
{
    [SerializeField] private ElementView _elementView;
    [SerializeField] private List<SceneCategoryData> _sceneCategories;
    [SerializeField] private GameObject _uiElement;

    public ElementModel ElementModel { get; private set; }

    
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
