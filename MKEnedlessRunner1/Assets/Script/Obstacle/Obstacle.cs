using UnityEngine;

public class Obstacle : ObstacleBase {
    
    public override void Update(){}

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerStatus.Instance.ItemScorePoint--;
            other.gameObject.GetComponent<PlayerMovement>().Damage();
        }
    }
    
}
