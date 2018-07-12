using UnityEngine;

public class PlayerStatus : SingletonMonoBehaviour<PlayerStatus> {

    //Hp
    private int hp = 3;
    public int Hp { get { return hp; } set { hp = value; } }
    //Item Point
    private int itemScorePoint = 0;
    public int ItemScorePoint
    {
        get { return itemScorePoint; }
        set { if (value > 0) itemScorePoint = value; }
    }
    //Distance
    [HideInInspector]
    public Vector3 StartPos = Vector3.zero;
    [HideInInspector]
    public Vector3 NowPos = Vector3.zero;
    private int distance = 0;
    public int Distance { get { return distance; } set { distance = value; } }

    public void Init()
    {
        Hp = 3;
        ItemScorePoint = 0;
        StartPos = Vector3.zero;
        NowPos = Vector3.zero;
        Distance = 0;
        Time.timeScale = 1;
    }

}
