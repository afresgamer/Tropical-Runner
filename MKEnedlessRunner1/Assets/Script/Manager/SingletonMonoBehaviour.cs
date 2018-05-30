using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T :MonoBehaviour {

    public static T Instance;
	
    //処理を軽くするためゲッターは省略
    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else { Instance = (T)FindObjectOfType(typeof(T)); }

        DontDestroyOnLoad(gameObject);
    }
}
