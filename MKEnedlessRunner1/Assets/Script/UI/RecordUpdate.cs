using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RecordUpdate : MonoBehaviour {

    //現得点とハイスコアテキスト
    [SerializeField, Header("現得点テキスト")]
    private Text scoreText;
    [SerializeField, Header("ハイスコアテキスト")]
    private Text HiScoreText;
    //アカウントと記録更新オブジェクト
    [Header("アカウントオブジェクト")]
    public GameObject AccountObj;
    private GameObject RecordUpdateObj;

    void Start () {
        //すでにログイン状態だったら即座に記録更新UIを表示する
        if (UserAuth.Instance.IsLogIn())
        {
            SwitchRecordCoroutine();
        }
        RecordUpdateObj = gameObject;
        scoreText.text = PlayerStatus.Instance.Score.ToString();
        HiScoreText.text = PlayerStatus.Instance.HiScore.ToString();
	}
	
    /// <summary>
    /// 認証済みだったら記録更新UIを表示する
    /// </summary>
    /// <returns></returns>
    public IEnumerator SwitchRecordCoroutine()
    {
        yield return UserAuth.Instance.IsLogIn();
        AccountObj.SetActive(false);
        RecordUpdateObj.SetActive(true);
    }

    public void SwitchRecordUpdate()
    {
        StartCoroutine(SwitchRecordCoroutine());
    }

    /// <summary>
    /// 認証解除されていたらログインUIを表示する
    /// </summary>
    public IEnumerator SwitchAccountCoroutine()
    {
        yield return !UserAuth.Instance.IsLogIn();
        AccountObj.SetActive(true);
        RecordUpdateObj.SetActive(false);
    }


    public void SwitchAccount()
    {
        StartCoroutine(SwitchAccountCoroutine());
    }

    /// <summary>
    /// 記録更新した後はタイトルに戻る
    /// </summary>
    public void UpdateRecord()
    {
        RankingUtil.Instance.FetchRanking(UserAuth.Instance.GetcurrentPlayer(),
            PlayerStatus.Instance.Score, GameManager.Instance.GetGameDifficulty);
        StartCoroutine(UpdateRecordCorotinue());
    }

    public IEnumerator UpdateRecordCorotinue()
    {
        yield return new WaitForSeconds(2.0f);
        SceneController.Instance.ChangeScene(SceneController.Scenes.Title);
        PlayerStatus.Instance.Init();
    }
}
