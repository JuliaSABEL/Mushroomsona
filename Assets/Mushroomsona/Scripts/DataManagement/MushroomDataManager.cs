using System.Collections.Generic;
using UnityEngine;


public class MushroomDataManager : MonoBehaviour
{
    [SerializeField] private List<string> _defaultSceneElements;
    [SerializeField] private string _defaultUICategory;
    
    public static MushroomDataManager Instance { get; private set; }
    public string DefaultUICategory { get; private set; }
    public List<string> DefaultSceneElements { get; private set; }
    public List<string> ActiveSceneElements { get; set; }
    
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        DefaultSceneElements = _defaultSceneElements;
        DefaultUICategory = _defaultUICategory;
    }
}
