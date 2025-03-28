using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewUICategoryData", menuName = "UI/UICategoryData")]
public class UICategoryData : ScriptableObject
{
    public List<UIElementData> uIElementsCollection;
}
