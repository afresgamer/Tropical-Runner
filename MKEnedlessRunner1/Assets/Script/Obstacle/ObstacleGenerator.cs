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
    //回転軸と位置
    Quaternion quaternion;
    float CreateHeight;

    Vector3 RandomPos()
    {
        Vector3 pos = new Vector3(Random.Range(-width, width), CreateHeight, Random.Range(-height, height));
        return transform.position + pos;
    }

    GameObject RandomItem()
    {
        int num = Random.Range(0, ObstableS.Length);
        quaternion = ObstableS[num].transform.rotation;
        CreateHeight = ObstableS[num].transform.position.y;
        return ObstableS[num];
    }

	void Start () {
		for(int i = 0; i < ItemNum; i++)
        {
            Instantiate(RandomItem(), RandomPos(), quaternion);
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width * 2, 0, height * 2));
    }
}
