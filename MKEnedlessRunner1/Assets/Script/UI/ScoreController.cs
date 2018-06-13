using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    [SerializeField, Header("得点テキスト")]
    private Text ScoreText;
    [SerializeField, Header("プレイヤーのHP")]
    private Player player;
    public GameObject[] HpImageS;

    void Start () {
        ScoreText.text = player.ItemScorePoint.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = player.ItemScorePoint.ToString();
        UpdateHp(player.Hp);
    }

    public void UpdateHp(int life)
    {
        for (int i = 0; i < HpImageS.Length; i++)
        {
            if (i < life) HpImageS[i].SetActive(true);
            else { HpImageS[i].SetActive(false); }
        }
    }
}
