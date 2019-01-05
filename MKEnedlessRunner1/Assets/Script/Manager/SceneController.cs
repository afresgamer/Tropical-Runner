using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController: SingletonMonoBehaviour<SceneController>{
    
    public enum Scenes { Title, Main, Result , UserAuth }
    [HideInInspector]
    public Scenes NowScene;

    /// <summary>
    /// シーン列挙型からシーン遷移
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
        NowScene = scene;
    }

    /// <summary>
    /// 文字列からシーン遷移
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        NowScene = (Scenes)System.Enum.Parse(typeof(Scenes), sceneName);
    }

}
