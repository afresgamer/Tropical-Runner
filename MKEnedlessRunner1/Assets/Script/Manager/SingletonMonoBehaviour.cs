using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

    public static T Instance;
    
    virtual protected void Awake()
    {
        if(Instance == null)
        {
            Instance = (T)FindObjectOfType(typeof(T));
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
