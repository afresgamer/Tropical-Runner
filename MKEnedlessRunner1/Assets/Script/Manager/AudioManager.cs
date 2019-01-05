using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonMonoBehaviour<AudioManager> {

    [SerializeField, Header("BGMの音の大きさ")]
    private float BGMVolume = 0.5f;
    [SerializeField, Header("BGMのピッチ")]
    private float BGMPitch = 1.0f;
    [SerializeField, Header("BGMのミュートフラグ")]
    private bool BGMIsMute = false;
    [SerializeField, Header("BGMのループするかどうか")]
    private bool BGMIsLoop = false;

    [SerializeField, Header("SEの音の大きさ")]
    private float SEVolume = 0.5f;
    [SerializeField, Header("SEのピッチ")]
    private float SEPitch = 1.0f;
    [SerializeField, Header("SEのミュートフラグ")]
    private bool SEIsMute = false;

    [SerializeField, Header("ゲームメインのBGM")]
    private AudioClip[] audioClips;

    /// <summary>
    /// BGM用のサウンド初期化
    /// </summary>
    /// <param name="bgm"></param>
    public void Init(BGM bgm)
    {
        bgm.audioSource.volume = BGMVolume;
        bgm.audioSource.pitch = BGMPitch;
        bgm.audioSource.mute = BGMIsMute;
        bgm.audioSource.loop = BGMIsLoop;
    }

    /// <summary>
    /// SE用のサウンド初期化
    /// </summary>
    /// <param name="se"></param>
    public void Init(SE se)
    {
        se.audioSource.volume = SEVolume;
        se.audioSource.pitch = SEPitch;
        se.audioSource.mute = SEIsMute;
    }

    /// <summary>
    /// ボリュームを設定(SE)
    /// </summary>
    /// <param name="se"></param>
    public void SetVolume(SE se)
    {
        se.audioSource.volume = SEVolume;
    }

    /// <summary>
    /// ボリュームを設定(SE)
    /// </summary>
    /// <param name="se"></param>
    /// <param name="_volume"></param>
    public void SetVolume(SE se,float _volume)
    {
        se.audioSource.volume = _volume;
    }

    /// <summary>
    /// ボリュームを設定(BGM)
    /// </summary>
    /// <param name="bgm"></param>
    public void SetVolume(BGM bgm)
    {
        bgm.audioSource.volume = BGMVolume;
    }

    /// <summary>
    /// ボリュームを設定(BGM)
    /// </summary>
    /// <param name="bgm"></param>
    /// <param name="_volume"></param>
    public void SetVolume(BGM bgm,float _volume)
    {
        bgm.audioSource.volume = _volume;
    }

    /// <summary>
    /// ピッチを設定(SE)
    /// </summary>
    /// <param name="se"></param>
    public void SetPitch(SE se)
    {
        se.audioSource.pitch = SEPitch;
    }

    /// <summary>
    /// ピッチを設定(BGM)
    /// </summary>
    /// <param name="bgm"></param>
    public void SetPitch(BGM bgm)
    {
        bgm.audioSource.pitch = BGMPitch;
    }

    /// <summary>
    /// ゲームメインのBGM設定用関数
    /// </summary>
    /// <param name="bgm"></param>
    /// <param name="num"></param>
    public void ChangeBGM(BGM bgm,int num)
    {
        bgm.audioSource.clip = audioClips[num];
        bgm.audioSource.Play();
    }
}
