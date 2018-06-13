using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonMonoBehaviour<SceneController> {
    
    //シーンの状態列挙体
    public enum SceneName { Main,Result }
    
    private SceneName sceneName;

    public void SceneChange(SceneName name)
    {
        SceneManager.LoadScene(name.ToString());
    }

    
}
