using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    //障害物の種類
    public GameObject[] ObstableS;
    //生成する障害物の数
    public int ItemNum = 6;
    //幅と奥行き
    public float width = 2;
    public float height = 10;
    //回転軸
    public Quaternion quaternion;

    Vector3 RandomPos()
    {
        Vector3 pos = new Vector3(Random.Range(-width, width), 0.5f, Random.Range(-height, height));
        return transform.position + pos;
    }

    GameObject RandomItem()
    {
        int num = Random.Range(0, ObstableS.Length);
        quaternion = ObstableS[num].transform.rotation;
        return ObstableS[num];
    }

	void Start () {
		for(int i = 0; i < ItemNum; i++)
        {
            Instantiate(RandomItem(), RandomPos(), quaternion);
        }
	}
}
