using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {
    //道のタイプ
    [Header("簡単な難易度の道")]
    public RoadType EasyType;
    [Header("普通の難易度の道")]
    public RoadType NormalType;
    [Header("難しい難易度の道")]
    public RoadType HardType;
    //道生成数管理リスト
    List<GameObject> roadList = new List<GameObject>();
    //最大道数
    const int RoadLength = 3;

    private void Start()
    {
        GameObject firstRoad = FindObjectOfType<Road>().gameObject;
        roadList.Add(firstRoad);
    }

    /// <summary>
    /// 道生成処理
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="num"></param>
    public void RoadCreate(Vector3 pos, int num)
    {
        GameObject road = Instantiate(SetRoad(num), pos, Quaternion.identity);
        roadList.Add(road);
        if (roadList.Count > RoadLength)
        {
            Destroy(roadList[0]);
            roadList.RemoveAt(0);
        }
    }

    /// <summary>
    /// ランダム道生成処理
    /// </summary>
    /// <param name="pos"></param>
    public void RandomRoadCreate(Vector3 pos)
    {
        GameObject road = Instantiate(SetRandomRoad(), pos, Quaternion.identity);
        roadList.Add(road);
        if (roadList.Count > RoadLength)
        {
            Destroy(roadList[0]);
            roadList.RemoveAt(0);
        }
    }

    /// <summary>
    /// ランダム道決定関数(Hard)
    /// </summary>
    /// <returns></returns>
    public GameObject SetRandomRoad()
    {
        //難易度を選択
        RoadType roadType = StageSelect(GameManager.Instance.GetGameDifficulty);
        int randomNum = Random.Range(0, roadType.RoadTypes.Length);
        return roadType.RoadTypes[randomNum];
    }

    /// <summary>
    /// 道決定関数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public GameObject SetRoad(int num)
    {
        //難易度を選択
        RoadType road = StageSelect(GameManager.Instance.GetGameDifficulty);
        return road.RoadTypes[num];
    }

    /// <summary>
    /// コース難易度をゲーム難易度から決定
    /// </summary>
    /// <param name="gameDifficulty"></param>
    /// <returns></returns>
    public RoadType StageSelect(GameManager.GameDifficulty gameDifficulty)
    {
        switch (gameDifficulty)
        {
            case GameManager.GameDifficulty.Easy:
                return EasyType;
            case GameManager.GameDifficulty.Normal:
                return NormalType;
            case GameManager.GameDifficulty.Hard:
                return HardType;
        }

        return EasyType;
    }
}
