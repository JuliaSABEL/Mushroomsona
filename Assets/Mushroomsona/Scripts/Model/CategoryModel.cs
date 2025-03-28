public class CategoryModel 
{
    public UICategoryData CategoryData { get; private set; }

    
    public CategoryModel(UICategoryData categoryData)
    {
        CategoryData = categoryData;
    }
}
