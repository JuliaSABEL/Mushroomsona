using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CategoryView
{
    private readonly Transform _elementsPanel;
    private readonly GameObject _elementButtonPrefab;
    private readonly List<GameObject> _elementsPool = new();

    
    public CategoryView(Transform elementsPanel, GameObject elementButtonPrefab)
    {
        _elementsPanel = elementsPanel;
        _elementButtonPrefab = elementButtonPrefab;
    }
    
    public void InitializeElements(UICategoryData category)
    {
        DeactivateElementsPanel();

        if (_elementsPool.Count <= 0)
        {
            for (int i = 0; i < category.uIElementsCollection.Count; i++)
            {
                _elementsPool.Add(GameObject.Instantiate(_elementButtonPrefab, _elementsPanel));
                
                var poolElement = _elementsPool[i];
                var dataElement = category.uIElementsCollection[i];
                
                poolElement.transform.Find("Icon").GetComponent<Image>().sprite = dataElement.sprite;
                poolElement.name = dataElement.elementName;
            }
        }
        else
        {
            foreach (var element in _elementsPool)
            {
                element.SetActive(true);
            }
            
        }
    }
    
    
    private void DeactivateElementsPanel()
    {
        foreach (Transform child in _elementsPanel)
        {
            child.gameObject.SetActive(false);
        }
    }
}
