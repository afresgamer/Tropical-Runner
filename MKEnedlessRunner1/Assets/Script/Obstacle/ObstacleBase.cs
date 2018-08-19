using UnityEngine;

public class ObstacleBase : MonoBehaviour {
    
    public virtual void Update() { }

    public virtual void OnTriggerEnter(Collider other){ }

    public void Spin(float RotSpeed)
    {
        transform.Rotate(Vector3.forward, RotSpeed * Time.deltaTime);
    }

}
