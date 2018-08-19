using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager> {

    //goto BGMクラスとSEクラスでそれぞれ音源をサウンド設定をいじれるようにする

    private bool isMute = false;
    private float Volume = 0;
    private float pitch = 0;
    private bool isLoop = false;

	void Start () {
		
	}
	
    /// <summary>
    /// ボリュームを設定
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="_volume"></param>
    public void SetVolume(AudioSource audioSource,float _volume)
    {
        audioSource.volume = _volume;
    }



}
