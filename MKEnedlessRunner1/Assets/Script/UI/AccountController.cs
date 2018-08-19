using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AccountController : MonoBehaviour {

    //入力フィールド
    [SerializeField, Header("名前入力フィールド")]
    private InputField idInputField;
    [SerializeField, Header("パスワード入力フィールド")]
    private InputField passInputField;
    //新規登録とログイン
    [SerializeField, Header("新規登録オブジェクト")]
    private GameObject SignUpObj;
    [SerializeField, Header("ログインオブジェクト")]
    private GameObject LogInObj;
    //トグルオブジェクト
    [SerializeField, Header("新規登録トグル")]
    private Toggle SignUpToggle;
    [SerializeField, Header("ログイントグル")]
    private Toggle LogInToggle;
    //警告用テキスト
    [SerializeField, Header("警告用テキスト")]
    private Text ReportText;
    
    public void SwitchState()
    {
        SignUpObj.SetActive(SignUpToggle.isOn);
        LogInObj.SetActive(LogInToggle.isOn);
    }

    /// <summary>
    /// アカウントを作成してスコアをサーバーに保存する
    /// </summary>
    public void CreateAccount()
    {
        if(idInputField != null && passInputField.text != null)
        {
            UserAuth.Instance.SignUp(idInputField.text, passInputField.text);
            StartCoroutine(SwitchTitle());
        }
        else
        {
            Debug.Log("ユーザー名とパスワードを入力してください");
            ReportText.text = "ユーザー名とパスワードを入力してください";
        }
        
    }

    public IEnumerator SwitchTitle()
    {
        //認証出来たらスコア更新
        yield return UserAuth.Instance.IsLogIn();
        RankingUtil.Instance.SaveRanking(idInputField.text, 
            PlayerStatus.Instance.Score, GameManager.Instance.GetGameDifficulty);
        //スコア更新が終わったらタイトルに戻る
        yield return new WaitForSeconds(2.0f);
        SceneController.Instance.ChangeScene(SceneController.Scenes.Title);
        PlayerStatus.Instance.Init();

    }

    /// <summary>
    /// アカウントを検索して登録されていたら、スコアを上書き保存する
    /// </summary>
    public void AccountLogIn()
    {
        if(idInputField != null && passInputField.text != null)
        {
            UserAuth.Instance.LogIn(idInputField.text, passInputField.text);
        }
        else
        {
            Debug.Log("ユーザー名とパスワードを入力してください");
            ReportText.text = "ユーザー名とパスワードを入力してください";
        }
    }

}
