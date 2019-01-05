using UnityEngine;
using UnityEngine.UI;

public class SetGameDifficulty : MonoBehaviour {
    
    private Button button;
    [Header("ゲーム難易度")]
    public GameManager.GameDifficulty gameDiff = GameManager.GameDifficulty.Easy;

	void Start () {
        button = GetComponent<Button>();
        SetGameDiff(button, gameDiff);
	}
	
    void SetGameDiff(Button _button, GameManager.GameDifficulty _gameDiff)
    {
        _button.onClick.AddListener(() => GameManager.Instance.SetGameDifficulty(_gameDiff));
        _button.onClick.AddListener(() => SceneController.Instance.ChangeScene(SceneController.Scenes.Main));
    }

}
