using System.Collections.Generic;
using UnityEngine;


public class ResetMushroomController : MonoBehaviour
{
    [SerializeField] private GameObject _sceneElementsCase;

    private ResetMushroomView _view;
    private List<string> _defaultElements;

    
    private void Start()
    {
        _view = new ResetMushroomView(_sceneElementsCase);
        _defaultElements = MushroomStateManager.Instance.DefaultSceneElements;
    }

    
    public void ClearMushroom()
    {
        foreach (var child in _view.GetChildren())
        {
            if (_defaultElements.Contains(child.name))
            {
                if (!child.gameObject.activeSelf)
                    _view.Activate(child);
            }
            else
            {
                _view.Destroy(child);
            }
        }
    }
}
