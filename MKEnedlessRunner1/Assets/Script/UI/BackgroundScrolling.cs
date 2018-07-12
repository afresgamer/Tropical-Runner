using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField, Header("横にスクロールするスピード")]
    private float X_speed = 1;
    [SerializeField, Header("下にスクロールするスピード")]
    private float Y_speed = 1;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        ScrollAnimation();
    }

    public void ScrollAnimation()
    {
        float x = Mathf.Repeat(-Time.time * X_speed, 1);
        float y = Mathf.Repeat(Time.time * Y_speed, 1);

        Vector2 v = new Vector2(x, y);

        image.material.SetTextureOffset("_MainTex", v);
    }
}
