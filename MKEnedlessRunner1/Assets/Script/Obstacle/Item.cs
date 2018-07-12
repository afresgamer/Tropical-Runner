using UnityEngine;

public class Item : ObstacleBase {

    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerStatus.Instance.ItemScorePoint++;
        }
    }
    
}
