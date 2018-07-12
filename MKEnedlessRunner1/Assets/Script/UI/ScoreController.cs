using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    [SerializeField, Header("得点テキスト")]
    private Text ScoreText;
    [SerializeField, Header("距離テキスト")]
    Text DistanceText;
    [SerializeField, Header("Pause画面")]
    private GameObject PauseWindow;
    public GameObject[] HpImageS;
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = PlayerStatus.Instance.ItemScorePoint.ToString();
        DistanceText.text = PlayerStatus.Instance.Distance.ToString();
        UpdateHp(PlayerStatus.Instance.Hp);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            PauseWindow.SetActive(true);
        }
    }

    /// <summary>
    /// Playerの体力表示,非表示
    /// </summary>
    /// <param name="life"></param>
    public void UpdateHp(int life)
    {
        for (int i = 0; i < HpImageS.Length; i++)
        {
            if (i < life) HpImageS[i].SetActive(true);
            else { HpImageS[i].SetActive(false); }
        }
    }

    public void RePlay()
    {
        Time.timeScale = 1;
        PauseWindow.SetActive(false);
    }

    public void ToTitle()
    {
        SceneController.Instance.ChangeScene("TestStageCreator");
        PlayerStatus.Instance.Init();
    }
}
