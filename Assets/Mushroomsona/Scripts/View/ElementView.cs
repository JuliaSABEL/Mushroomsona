using System;
using System.Collections.Generic;
using UnityEngine;


public class ElementView : MonoBehaviour
{
    [SerializeField] private List<SceneElementData> _startSceneElements;
    [SerializeField] private List<SceneCategoryData> _sceneCategories;
    private Transform _elementCase;
    [SerializeField] private GameObject _elementPrefab;
    private List<GameObject> _elementPool = new();
    private List<GameObject> _categoryPool = new();
    private SceneCategoryData _category;
    private SceneElementData _element;
    
    
    private void Start()
    {
        _elementCase = GameObject.Find("SceneElements").transform;
    }
    
    
    public void OnElementButtonClicked()
    {
        SelectSceneData(_sceneCategories);
        InitializeElement(_element);
    }


    private void StartInitialization()
    {
        
    }
    
    private void SelectSceneData(List<SceneCategoryData> sceneCategories)
    {
        foreach (var category in sceneCategories)
        {
            foreach (var element in category.sceneElementsCollection)
            {
                if (element.elementName == gameObject.name)
                {
                    _category = category;
                    _element = element;
                }
            }
        }
    }
    
    private void InitializeElement(SceneElementData element)
    {
        // DeactivateCategory();
        //
        // if (_elementPool.Count <= 0)
        // {
        //     _elementPool.Add(Instantiate(_elementPrefab, _elementCase)); 
        //     
        //     _elementPool[0].GetComponent<SpriteRenderer>().sprite = element.sprite;
        //     for (int i = 0; i < category.uIElementsCollection.Count; i++)
        //     {
        //         _elementsPool.Add(Instantiate(_elementButtonPrefab, _elementsPanel));
        //         
        //         var poolElement = _elementsPool[i];
        //         var dataElement = category.uIElementsCollection[i];
        //         
        //         poolElement.transform.Find("Icon").GetComponent<Image>().sprite = dataElement.sprite;
        //         poolElement.name = dataElement.elementName;
        //     }
        // }
        // else
        // {
        //     foreach (var /*element*/ in _elementsPool)
        //     {
        //         element.SetActive(true);
        //     }
        //     
        // }
    }
    
    private void DeactivateCategory()
    {
        if (_categoryPool.Count > 0)
        {
            foreach (var child in _categoryPool)
            {
                child.SetActive(false);
            } 
        }
    }
}
