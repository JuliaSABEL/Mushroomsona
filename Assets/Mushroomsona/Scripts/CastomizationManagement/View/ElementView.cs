using UnityEngine;


public class ElementView
{
    public GameObject PoolElement { get; private set; }
    
    private readonly GameObject _elementPrefab;
    private readonly Transform _elementCase;
    
    
    public ElementView(GameObject elementPrefab, Transform elementCase)
    {
        _elementPrefab = elementPrefab;
        _elementCase = elementCase;
    }
    
    public void InitializeElement(SceneElementData element, SceneCategoryData category)
    {
        DeactivateCategoryElements(element, category);
        
        if (PoolElement == null)
        {
            GameObject sceneElement = FindSceneElement(element.elementName);
            
            if (sceneElement != null)
            {
                PoolElement = sceneElement;
            }
            else
            {
                PoolElement = GameObject.Instantiate(_elementPrefab, _elementCase);
                var spriteRenderer = PoolElement.GetComponent<SpriteRenderer>();

                spriteRenderer.sprite = element.sprite;
                spriteRenderer.sortingOrder = category.layer;
                PoolElement.name = element.elementName;
                PoolElement.transform.position = element.position;
            }
        }

        PoolElement.SetActive(true);
    }
    
    
    private static GameObject FindSceneElement(string name)
    {
        var allObjects = Object.FindObjectsByType<GameObject>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        foreach (var obj in allObjects)
        {
            if (obj.name == name && obj.GetComponentInParent<Canvas>() == null)
            {
                return obj;
            }
        }

        return null;
    }
    
    private void DeactivateCategoryElements(SceneElementData element, SceneCategoryData category)
    {
        foreach (Transform child in _elementCase)
        {
            foreach (var elementData in category.sceneElementsCollection)
            {
                if (child.gameObject.name == elementData.elementName && child.gameObject.name != element.elementName)
                {
                    child.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
