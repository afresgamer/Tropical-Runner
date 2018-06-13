﻿using UnityEngine;

public class Road : MonoBehaviour {
    
    public Transform SetRoadPos()
    {
        return transform.Find("AttachPoint");
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player next road Create");
            RoadGenerator.Instance.RandomRoadCreate(SetRoadPos().position);
        }
    }
}
