using UnityEngine;


public class CategoryController : MonoBehaviour
{
    [SerializeField] private Transform _elementsPanel;
    [SerializeField] private GameObject _elementButtonPrefab;
    [SerializeField] private UICategoryData _categoryData;

    private CategoryModel _categoryModel;
    private CategoryView _categoryView;
    
    
    private void Start()
    {
        _categoryModel = new CategoryModel(_categoryData);
        _categoryView = new CategoryView(_elementsPanel, _elementButtonPrefab);

        if (gameObject.name == MushroomStateManager.Instance.DefaultUICategory)
            _categoryView.InitializeElements(_categoryModel.CategoryData);
    }
    
    
    public void OnCategoryButtonClicked()
    {
        _categoryView.InitializeElements(_categoryModel.CategoryData);
    }
}
