using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewUICategoryData", menuName = "UI/UICategoryData")]
public class UICategoryData : ScriptableObject
{
    public string _name;
    public List<UIElementData> _uIElementsCollection;
}
