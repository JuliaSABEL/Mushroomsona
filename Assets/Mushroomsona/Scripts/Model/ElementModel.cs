using System.Collections.Generic;
using UnityEngine;


public class ElementModel
{
    public SceneCategoryData CategoryData { get; private set; }
    public SceneElementData ElementData { get; private set; }

    
    public ElementModel(List<SceneCategoryData> sceneCategories, GameObject uiElement)
    {
        SetSceneData(sceneCategories, uiElement);
    }

    
    private void SetSceneData(List<SceneCategoryData> sceneCategories, GameObject uiElement)
    {
        foreach (var category in sceneCategories)
        {
            foreach (var element in category.sceneElementsCollection)
            {
                if (element.elementName == uiElement.name)
                {
                    CategoryData = category;
                    ElementData = element;
                    return;
                }
            }
        }
    }
}
