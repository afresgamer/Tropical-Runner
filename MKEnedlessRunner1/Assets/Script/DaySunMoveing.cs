using UnityEngine;

public class DaySunMoveing : MonoBehaviour {

    [SerializeField, Header("時の速さ")]
    private float day_speed = 1f;

	void Update () {
        transform.rotation = transform.rotation * Quaternion.Euler
            (day_speed * Time.deltaTime, 0, 0);
        //Debug.Log(transform.rotation);
	}
}
