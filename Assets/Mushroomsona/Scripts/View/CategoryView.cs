using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CategoryView : MonoBehaviour
{
    [SerializeField] private GameObject _elementsPanel;
    [SerializeField] private GameObject _elementButtonPrefab;
    [SerializeField] private UICategoryData _categoryData;
    private List<GameObject> _elementsPool = new List<GameObject>();

    
    public void ChangeCategory()
    {
        DeactivateElementsPanel();
        
        InitializeCurrentElements(_categoryData);
    }
    
    
    private void DeactivateElementsPanel()
    {
        foreach (Transform child in _elementsPanel.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void InitializeCurrentElements(UICategoryData category)
    {
        if (_elementsPool.Count <= 0)
        {
            for (int i = 0; i < category._uIElementsCollection.Count; i++)
            {
                _elementsPool.Add(Instantiate(_elementButtonPrefab, _elementsPanel.transform));
                _elementsPool[i].transform.Find("Icon").GetComponent<Image>().sprite = category._uIElementsCollection[i]._sprite;
                _elementsPool[i].name = category._uIElementsCollection[i]._name;
            }
        }
        else
        {
            foreach (GameObject element in _elementsPool)
            {
                element.SetActive(true);
            }
            
        }
    }
}
