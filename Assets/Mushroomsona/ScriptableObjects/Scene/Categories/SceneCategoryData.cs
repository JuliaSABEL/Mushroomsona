using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSceneCategory", menuName = "Scene/SceneCategory")]
public class SceneCategoryData : ScriptableObject
{
    public List<SceneElementData> sceneElementsCollection;
    public string categoryName;
    public int layer;
}
