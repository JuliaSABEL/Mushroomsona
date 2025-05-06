using System.Collections.Generic;
using UnityEngine;


public class ElementView : MonoBehaviour
{
    [SerializeField] private List<SceneCategoryData> _sceneCategories;
    [SerializeField] private GameObject _elementPrefab;
    private Transform _elementCase;
    private SceneCategoryData _categoryData;
    private SceneElementData _elementData;
    private GameObject _poolElement;


    private void Start()
    {
        _elementCase = GameObject.Find("SceneElements").transform;
    }


    public void OnElementButtonClicked()
    {
        SetSceneData(_sceneCategories);

        if (_poolElement != null && _poolElement.activeSelf && _categoryData.isCategoryInvulnerable == false)
        {
            _poolElement.SetActive(false);
        }
        else
        {
            InitializeElement(_elementData);
        }
    }


    private void SetSceneData(List<SceneCategoryData> sceneCategories)
    {
        foreach (var category in sceneCategories)
        {
            foreach (var element in category.sceneElementsCollection)
            {
                if (element.elementName == gameObject.name)
                {
                    _categoryData = category;
                    _elementData = element;
                }
            }
        }
    }

    private void InitializeElement(SceneElementData element)
    {
        DeactivateCategoryElements();

        if (_poolElement == null)
        {
            _poolElement = Instantiate(_elementPrefab, _elementCase);

            var spriteRenderer = _poolElement.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = element.sprite;
            spriteRenderer.sortingOrder = _categoryData.layer;
            _poolElement.name = element.elementName;
            _poolElement.transform.position = element.position;
        }
        
        _poolElement.SetActive(true);
    }

    private void DeactivateCategoryElements()
    {
        foreach (Transform child in _elementCase)
        {
            for (int i = 0; i < _categoryData.sceneElementsCollection.Count; i++)
            {
                foreach (SceneElementData elementData in _categoryData.sceneElementsCollection)
                {
                    if (child.gameObject.name == elementData.elementName)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}