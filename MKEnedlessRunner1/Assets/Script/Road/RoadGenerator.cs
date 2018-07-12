using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {
    //道のタイプ
    public RoadType roadType;
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
        return roadType.RoadTypes[num];
    }
}
