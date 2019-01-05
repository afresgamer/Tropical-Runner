using UnityEngine;
using UnityEngine.UI;

public class SE : MonoBehaviour {
    
    [HideInInspector]
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.Init(this);
    }

    public void ChangeVolume(Slider slider)
    {
        AudioManager.Instance.SetVolume(this, slider.value);
    }

    public void PlaySE()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
