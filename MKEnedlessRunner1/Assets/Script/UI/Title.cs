using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Title : MonoBehaviour {

    [SerializeField, Header("タイトル画面")]
    private GameObject TitleImage;
    [SerializeField, Header("ゲーム難易度画面")]
    private GameObject GameModeImage;
    [SerializeField, Header("オプション画面")]
    private GameObject OptionImage;
    [SerializeField, Header("サウンド設定画面")]
    private GameObject SoundSetting;
    [SerializeField, Header("ランキング表示画面")]
    private GameObject RankingWindow;

    private void Start()
    {
        TitleImage.SetActive(true);
        GameModeImage.SetActive(false);
        TitleImage.GetComponent<RectTransform>().DOAnchorPosY(-25, 1.0f);
    }

    /// <summary>
    /// 各状態に移動するための関数(タイトル,オプション,etc)
    /// </summary>
    public void SetTitle()
    {
        OptionImage.GetComponent<RectTransform>().DOAnchorPosY(500, 1.0f);
        StartCoroutine(WaitTitle(1.0f));
    }

    public void SetGameMode()
    {
        TitleImage.GetComponent<RectTransform>().DOAnchorPosY(-500, 1.0f);
        StartCoroutine(WaitGameMode(1.0f));
    }

    public void SetOption()
    {
        TitleImage.GetComponent<RectTransform>().DOAnchorPosY(-500, 1.0f);
        StartCoroutine(WaitOption(1.0f));
    }

    public void SetSoundSetting()
    {
        OptionImage.GetComponent<RectTransform>().DOAnchorPosY(500, 1.0f);
        StartCoroutine(WaitSoundSetting(1.0f));
    }

    public void SetRankingWindow()
    {
        //ログインしているかどうかを確認してログイン状態だったらランキングウィンドウを表示する
        if (UserAuth.Instance.IsLogIn())
        {
            OptionImage.GetComponent<RectTransform>().DOAnchorPosY(500, 1.0f);
            StartCoroutine(WaitRankingWindow(1.0f));
        }
        else
        {
            SceneController.Instance.ChangeScene(SceneController.Scenes.UserAuth);
        }
        
    }

    /// <summary>
    /// 各状態に戻るための関数
    /// </summary>
    public void ToOption()
    {
        if(SoundSetting.GetComponent<RectTransform>().anchoredPosition.x == 0)
        {
            SoundSetting.GetComponent<RectTransform>().DOAnchorPosX(-650, 1.0f);
        }
        else if(RankingWindow.GetComponent<RectTransform>().anchoredPosition.x == 0)
        {
            RankingWindow.GetComponent<RectTransform>().DOAnchorPosX(650, 1.0f);
        }
        StartCoroutine(WaitOption(1.0f));
    }

    public void BackToTitle()
    {
        if (SoundSetting.GetComponent<RectTransform>().anchoredPosition.x == 0)
        {
            SoundSetting.GetComponent<RectTransform>().DOAnchorPosX(-650, 1.0f);
        }
        else if (RankingWindow.GetComponent<RectTransform>().anchoredPosition.x == 0)
        {
            RankingWindow.GetComponent<RectTransform>().DOAnchorPosX(650, 1.0f);
        }
        StartCoroutine(WaitTitle(1.0f));
    }

    /// <summary>
    /// 待機時間後に行う処理するためのコルーチン群
    /// </summary>
    
    private IEnumerator WaitTitle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        TitleImage.GetComponent<RectTransform>().DOAnchorPosY(-25, 1.0f);
    }

    private IEnumerator WaitGameMode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameModeImage.SetActive(true);
    }

    private IEnumerator WaitOption(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OptionImage.GetComponent<RectTransform>().DOAnchorPosY(0, 1.0f);
    }
    
    private IEnumerator WaitSoundSetting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SoundSetting.GetComponent<RectTransform>().DOAnchorPosX(0, 1.0f);
    }

    private IEnumerator WaitRankingWindow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        RankingWindow.GetComponent<RectTransform>().DOAnchorPosX(0, 1.0f);
    }


}
