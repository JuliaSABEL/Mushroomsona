using UnityEngine;


public class CategoryController : MonoBehaviour
{
    [SerializeField] private CategoryView _categoryView;
    [SerializeField] private UICategoryData _categoryData;
    private CategoryModel _categoryModel;
    
    
    private void Awake()
    {
        _categoryModel = new CategoryModel(_categoryData);
    }
    
    
    public void OnCategoryButtonClicked()
    {
        _categoryView.InitializeElements(_categoryModel.CategoryData);
    }
}
