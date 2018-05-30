using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : SingletonMonoBehaviour<RoadGenerator> {
    //道のタイプ
    public RoadType roadType;
    //道生成数管理リスト
    List<GameObject> roadList = new List<GameObject>();
    //最大道数
    const int RoadLength = 3;

    private void Start()
    {
        GameObject FirstRoad = FindObjectOfType<Road>().gameObject;
        roadList.Add(FirstRoad);
    }

    //道生成処理
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

    //ランダム道生成処理
    public void RandomRoadCreate(Vector3 pos)
    {
        GameObject road = Instantiate(SetRandomRoad(),pos,Quaternion.identity);
        roadList.Add(road);
        if (roadList.Count > RoadLength)
        {
            Destroy(roadList[0]);
            roadList.RemoveAt(0);
        }
    }

    //ランダム道決定関数(Hard)
    public GameObject SetRandomRoad()
    {
        int randomNum = Random.Range(0, roadType.RoadTypes.Length);
        return roadType.RoadTypes[randomNum];
    }

    //道決定関数
    public GameObject SetRoad(int num)
    {
        return roadType.RoadTypes[num];
    }
}
