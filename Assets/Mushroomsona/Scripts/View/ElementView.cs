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
        DeactivateCategoryElements(category);

        if (PoolElement == null)
        {
            PoolElement = Instantiate(_elementPrefab, _elementCase);
            var spriteRenderer = PoolElement.GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = element.sprite;
            spriteRenderer.sortingOrder = category.layer;
            PoolElement.name = element.elementName;
            PoolElement.transform.position = element.position;
        }

        PoolElement.SetActive(true);
    }

    
    private void DeactivateCategoryElements(SceneCategoryData category)
    {
        foreach (Transform child in _elementCase)
        {
            foreach (var elementData in category.sceneElementsCollection)
            {
                if (child.gameObject.name == elementData.elementName)
                {
                    child.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
