using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class MusicScript : MonoBehaviour
{
    

    AudioSource audioSource;
    double pauseClipTime = 0;
    public AudioClip[] clips;
    int actualClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.time >= clips[actualClip].length)
        {
            actualClip++;
            if(actualClip > clips.Length - 1)
            {
                actualClip = 0;
            }
            audioSource.clip = clips[actualClip];
            audioSource.Play();
        }
    }

    public void OnPauseGame()
    {
        pauseClipTime = audioSource.time;
        audioSource.Pause();
    }

    public void OnResumeGame()
    {
        audioSource.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;
    }

    public void PitchThis(float pitch)
    {
       audioSource.pitch = pitch;
    }
}
