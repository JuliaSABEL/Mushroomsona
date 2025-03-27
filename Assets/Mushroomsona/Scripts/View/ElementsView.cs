using UnityEngine;

public class ElementsView : MonoBehaviour
{
    
    private void ClearElementsPanel()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
