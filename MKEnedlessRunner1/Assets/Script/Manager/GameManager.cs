using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public enum GameDifficulty { Easy, Normal, Hard }
    private GameDifficulty NowGameDifficulty;
    public GameDifficulty GetGameDifficulty { get { return NowGameDifficulty; } }
    
    /// <summary>
    /// ゲーム難易度を設定
    /// </summary>
    /// <param name="gameDifficulty"></param>
    public void SetGameDifficulty(GameDifficulty gameDifficulty)
    {
        NowGameDifficulty = gameDifficulty;
    }

    public void SetGameDifficulty(string gameDiffName)
    {
        NowGameDifficulty = (GameDifficulty)Enum.Parse(typeof(GameDifficulty),gameDiffName);
    }

}
