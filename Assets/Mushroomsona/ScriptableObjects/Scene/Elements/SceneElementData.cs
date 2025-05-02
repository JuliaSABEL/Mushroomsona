using UnityEngine;


[CreateAssetMenu(fileName = "NewSceneElement", menuName = "Scene/SceneElement")]
public class SceneElementData : ScriptableObject
{
    public string elementName;
    public Sprite sprite;
    public Vector2 position;
}
