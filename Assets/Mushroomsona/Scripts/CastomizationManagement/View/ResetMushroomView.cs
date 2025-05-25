using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ResetMushroomView
{
    private readonly GameObject _sceneElementsCase;

    
    public ResetMushroomView(GameObject sceneElementsCase)
    {
        _sceneElementsCase = sceneElementsCase;
    }

    public IEnumerable<Transform> GetChildren()
    {
        return _sceneElementsCase.transform.Cast<Transform>();
    }

    public void Activate(Transform t) => t.gameObject.SetActive(true);
    public void Destroy(Transform t) => GameObject.Destroy(t.gameObject);
}
