using UnityEngine;


public class CategoryController : MonoBehaviour
{
    [SerializeField] private CategoryView _categoryView;
    [SerializeField] private UICategoryData _categoryData;
    private CategoryModel _categoryModel;
    
    
    private void Awake()
    {
        _categoryModel = new CategoryModel(_categoryData);

        if (gameObject.name == "BodyColor")
            _categoryView.InitializeElements(_categoryModel.CategoryData);
    }
    
    
    public void OnCategoryButtonClicked()
    {
        _categoryView.InitializeElements(_categoryModel.CategoryData);
    }
}
