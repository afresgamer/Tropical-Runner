using UnityEngine;

public class ObstacleBase : MonoBehaviour {

    public float SpinSpeed = 10;
    
    public virtual void Update()
    {
        transform.Rotate(Vector3.forward, SpinSpeed * Time.deltaTime);
    }

    public virtual void OnCollisionEnter(Collision collision){}
}
