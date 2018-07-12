using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Result : MonoBehaviour {
    
    [SerializeField, Header("得点テキスト")]
    private Text ScoreText;
    [SerializeField, Header("距離テキスト")]
    private Text DistanceText;
    [SerializeField, Header("リプレイ用のボタン")]
    private Button ReplayButton;
    [SerializeField, Header("タイトルに戻るボタン")]
    private Button TotitleButton;

    private void Start()
    {
        StartCoroutine(ResultAnimation());
        ResultAction();
    }

    public IEnumerator ResultAnimation()
    {
        ScoreText.DOFade(1, 5.0f);
        ScoreText.rectTransform.parent.GetComponent<Text>().DOFade(1, 5.0f);
        DistanceText.DOFade(1, 5.0f);
        DistanceText.rectTransform.parent.GetComponent<Text>().DOFade(1, 5.0f);
        yield return new WaitForSeconds(5.0f);
        ReplayButton.enabled = true;
        TotitleButton.enabled = true;
    }

    /// <summary>
    /// リザルト用の処理
    /// </summary>
	public void ResultAction()
    {
        ScoreText.text = PlayerStatus.Instance.ItemScorePoint.ToString();
        DistanceText.text = PlayerStatus.Instance.Distance.ToString();
        ReplayButton.onClick.AddListener(() => Replay());
        TotitleButton.onClick.AddListener(() => Totitle());
    }

    public void Replay()
    {
        SceneController.Instance.ChangeScene("TestStageCreator");
        PlayerStatus.Instance.Init();
    }

    public void Totitle()
    {
        SceneController.Instance.ChangeScene("Title");
        PlayerStatus.Instance.Init();
    }
}
