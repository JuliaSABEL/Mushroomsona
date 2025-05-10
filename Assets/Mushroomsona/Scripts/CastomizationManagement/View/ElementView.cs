using UnityEngine;


public class ElementView : MonoBehaviour
{
    [SerializeField] private GameObject _elementPrefab;
    public GameObject PoolElement { get; private set; }
    
    private Transform _elementCase;

    
    private void Start()
    {
        _elementCase = GameObject.Find("SceneElements")?.transform;
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
                PoolElement = Instantiate(_elementPrefab, _elementCase);
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
