using UnityEngine;
using UnityEngine.UI;

public class ItemScore : MonoBehaviour {

    Text ScoreText;
    [Header("プレイヤー情報")]
    public Player player;

	void Start () {
        ScoreText = GetComponent<Text>();
        ScoreText.text = player.ItemScorePoint.ToString();
	}
	
	void Update () {
        ScoreText.text = player.ItemScorePoint.ToString();
	}
}
