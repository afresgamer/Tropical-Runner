using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour {

    [HideInInspector]
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.Init(this);

        if (SceneController.Instance.NowScene == SceneController.Scenes.Main)
        {
            //シーンがゲームメインだったら難易度ごとBGM変更
            switch (GameManager.Instance.GetGameDifficulty)
            {
                case GameManager.GameDifficulty.Easy:
                    AudioManager.Instance.ChangeBGM(this, 0);
                    break;
                case GameManager.GameDifficulty.Normal:
                    AudioManager.Instance.ChangeBGM(this, 1);
                    break;
                case GameManager.GameDifficulty.Hard:
                    AudioManager.Instance.ChangeBGM(this, 2);
                    break;
            }
        }
    }

    public void ChangeVolume(Slider slider)
    {
        AudioManager.Instance.SetVolume(this, slider.value);
    }

}
