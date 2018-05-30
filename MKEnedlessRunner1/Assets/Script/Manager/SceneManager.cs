using UnityEngine;

public class SceneManager : SingletonMonoBehaviour<SceneManager> {

    //各シーン名
    [Header("各シーン名")]
    public string TitleName;
    public string MainName;
    public string ResultName;
    //シーンの状態列挙体
    public enum SceneName { Title,Main,Result }
    [HideInInspector]
    public SceneName sceneName;

    public void SceneChange(SceneName name)
    {
        switch (name)
        {
            case SceneName.Title:
                UnityEngine.SceneManagement.SceneManager.LoadScene(TitleName);
                break;
            case SceneName.Main:
                UnityEngine.SceneManagement.SceneManager.LoadScene(MainName);
                break;
            case SceneName.Result:
                UnityEngine.SceneManagement.SceneManager.LoadScene(ResultName);
                break;
        }
    }

    
}
