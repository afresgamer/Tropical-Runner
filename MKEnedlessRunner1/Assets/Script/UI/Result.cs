using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Result : MonoBehaviour {
    
    [SerializeField, Header("アイテム獲得数テキスト")]
    private Text ItemPointText;
    [SerializeField, Header("距離テキスト")]
    private Text DistanceText;
    [SerializeField, Header("総合得点テキスト")]
    private Text ScoreText;
    [SerializeField, Header("リプレイ用のボタン")]
    private Button ReplayButton;
    [SerializeField, Header("タイトルに戻るボタン")]
    private Button TotitleButton;
    [SerializeField, Header("ランキングを作成するボタン")]
    private Button RankingCreateButton;

    private void Start()
    {
        StartCoroutine(ResultAnimation());
        ResultAction();
    }

    public IEnumerator ResultAnimation()
    {
        ItemPointText.DOFade(1, 5.0f);
        ItemPointText.rectTransform.parent.GetComponent<Text>().DOFade(1, 5.0f);
        DistanceText.DOFade(1, 5.0f);
        DistanceText.rectTransform.parent.GetComponent<Text>().DOFade(1, 5.0f);
        yield return new WaitForSeconds(2.5f);
        ScoreText.DOFade(1, 5.0f);
        ScoreText.rectTransform.parent.GetComponent<Text>().DOFade(1, 5.0f);
        yield return new WaitForSeconds(5.0f);
        ReplayButton.enabled = true;
        TotitleButton.enabled = true;
        RankingCreateButton.enabled = true;
    }

    /// <summary>
    /// リザルト用の処理
    /// </summary>
	public void ResultAction()
    {
        ItemPointText.text = PlayerStatus.Instance.ItemScorePoint.ToString();
        DistanceText.text = PlayerStatus.Instance.Distance.ToString();
        ScoreText.text = PlayerStatus.Instance.Score.ToString();
        ReplayButton.onClick.AddListener(() => Replay());
        TotitleButton.onClick.AddListener(() => Totitle());
        RankingCreateButton.onClick.AddListener(() => RankingCreate());
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

    public void RankingCreate()
    {
        SceneController.Instance.ChangeScene("UserAuth");
    }
}
