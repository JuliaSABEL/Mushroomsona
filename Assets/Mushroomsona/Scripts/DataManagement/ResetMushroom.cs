using System.Collections.Generic;
using UnityEngine;


public class ResetMushroom : MonoBehaviour
{
    [SerializeField] private GameObject _sceneElementsCase;
    
    private List<string> _defaultSceneElements;


    private void Start()
    {
        _defaultSceneElements = MushroomDataManager.Instance.DefaultSceneElements;
    }

    
    public void ClearMushroom()
    {
        foreach (Transform child in _sceneElementsCase.transform)
        {
            string childName = child.gameObject.name;

            if (_defaultSceneElements.Contains(childName))
            {
                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                }
            }
            else
            {
                Destroy(child.gameObject);
            }
        }
    }
}
