using System.Collections.Generic;


public class CategoryModel
{
    private Dictionary<string, List<UICategoryData>> _categories;

    public CategoryModel(Dictionary<string, List<UICategoryData>> categoriesData)
    {
        _categories = categoriesData;
    }

    public List<UICategoryData> GetElementsForCategory(string category)
    {
        return _categories.ContainsKey(category) ? _categories[category] : new List<UICategoryData>();
    }
}
