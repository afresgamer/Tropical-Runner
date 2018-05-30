using UnityEngine;

public class Obstacle : ObstacleBase {
    
    public override void Update(){}

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().ItemScorePoint--;
            collision.gameObject.GetComponent<Player>().Damage();
        }
    }
}
