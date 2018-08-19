using UnityEngine;
using NCMB;

public class UserAuth : SingletonMonoBehaviour<UserAuth> {
    
    private string currentPlayerName = "";

    public string GetcurrentPlayer() { return currentPlayerName; }

    /// <summary>
    /// mobile backendに接続してログイン
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pw"></param>
    public void LogIn(string id, string pw)
    {
        NCMBUser.LogInAsync(id, pw, (NCMBException e) =>
        {
            if(e != null)
            {
                //接続失敗したら
                Debug.LogError("ログインに失敗: " + e.ErrorMessage);
            }
            else
            {
                //接続成功したら
                currentPlayerName = id;
                Debug.Log(currentPlayerName + " ログインに成功");
            }
        });
    }

    /// <summary>
    /// mobile backendに接続して新規会員登録
    /// </summary>
    /// <param name="id"></param>
    /// <param name="mail"></param>
    /// <param name="pw"></param>
    public void SignUp(string id, string pw)
    {
        NCMBUser user = new NCMBUser
        {
            UserName = id,
            Password = pw
        };
        user.SignUpAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError("新規登録に失敗 : " + e.ErrorMessage);
            }
            else
            {
                currentPlayerName = id;
                Debug.Log(currentPlayerName + " 新規登録に成功");
            }
        });
    }

    /// <summary>
    /// mobile backendに接続してログアウト
    /// </summary>
    public void LogOut()
    {
        NCMBUser.LogOutAsync((NCMBException e) =>
        {
            if(e != null)
            {
                Debug.LogError("ログアウトに失敗 : " + e.ErrorMessage);
            }
            else
            {
                Debug.Log(currentPlayerName + " ログアウトします。");
                currentPlayerName = null;
            }
        });
    }

    /// <summary>
    /// ログインしているかどうか取得
    /// </summary>
    /// <returns></returns>
    public bool IsLogIn()
    {
        return NCMBUser.CurrentUser.IsAuthenticated();
    }
}
