using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("音樂列表")]
    [SerializeField]
    private AudioClip[ ] AudioList = null;

    private AudioSource soundEffect;
    private bool canPlayAudio;

    void Start ()
    {
        soundEffect = GetComponent<AudioSource> ();
        canPlayAudio = false;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (!canPlayAudio)
        {
            if (GameManager.Instance.GameStatus == Status.Play)
            {
                soundEffect.enabled = true;
                canPlayAudio = true;
            }
        }
        else if (GameManager.Instance.GameStatus == Status.Over)
        {
            soundEffect.enabled = false;
            canPlayAudio = false;
        }
    }

    /// <summary>
    /// 單次播放AudioList內的音效 (歌曲編號 0~?, 音量大小 0~1)
    /// </summary>
    /// <param name="AudioNum">歌曲編號 0~?</param>
    /// <param name="AudioVolume">音量大小 0~1</param>
    public void PlayAudio (int AudioNum, float AudioVolume)
    {
        soundEffect.volume = AudioVolume;
        soundEffect.PlayOneShot (AudioList[AudioNum]);
    }
}
