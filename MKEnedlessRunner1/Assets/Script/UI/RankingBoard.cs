using UnityEngine;
using UnityEngine.UI;

public class RankingBoard : MonoBehaviour {

    [SerializeField, Header("ユーザー名テキスト")]
    private Text UserName;
    [SerializeField, Header("ハイスコアテキスト")]
    private Text HiScoreText;
    [SerializeField, Header("トップ5テキスト")]
    private Text[] RankingTexts;

	void Start () {
        UserName.text = UserAuth.Instance.GetcurrentPlayer();
        HiScoreText.text = PlayerStatus.Instance.HiScore.ToString();
        //トップ5の表示するための処理
        RankingUtil.Instance.GetScoreRanking(GameManager.Instance.GetGameDifficulty);

        if(RankingTexts.Length > RankingUtil.Instance.rankingList.Count)
        {
            for (int i = 0; i < RankingUtil.Instance.rankingList.Count; i++)
            {
                RankingTexts[i].text += "   " + RankingUtil.Instance.rankingList[i]._name
                    + "     " + RankingUtil.Instance.rankingList[i]._score.ToString();
            }

            for (int i = RankingUtil.Instance.rankingList.Count; i < RankingTexts.Length; i++)
            {
                RankingTexts[i].text += "   " + "NONE";
            }
        }
        else if(RankingTexts.Length == RankingUtil.Instance.rankingList.Count)
        {
            for (int i = 0; i < RankingUtil.Instance.rankingList.Count; i++)
            {
                RankingTexts[i].text += "   " + RankingUtil.Instance.rankingList[i]._name
                    + "     " + RankingUtil.Instance.rankingList[i]._score.ToString();
            }
        }
        else
        {
            for (int i = 0; i < RankingTexts.Length; i++)
            {
                RankingTexts[i].text += "   " + "NONE";
            }
        }
        
    }

}
