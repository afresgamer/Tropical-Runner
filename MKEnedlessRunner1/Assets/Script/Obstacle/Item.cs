using UnityEngine;

public class Item : ObstacleBase {

    public float SpinSpeed = 10.0f;

    public override void Update()
    {
        Spin(SpinSpeed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerStatus.Instance.ItemScorePoint++;
        }
    }

}
