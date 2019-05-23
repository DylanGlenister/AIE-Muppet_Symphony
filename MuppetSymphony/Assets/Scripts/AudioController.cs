using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Tooltip("Gets Audio Source attached to current object")]
    public AudioSource musicControl;
    [Tooltip("Time before audio clip starts (in secs)")]
    public float audioDelay = 5.65f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        musicControl = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(musicControl.clip != null)
        {
            timer += Time.deltaTime;

          if (timer >= audioDelay && !musicControl.isPlaying)
          {
            musicControl.Play();
          }
        }
    }
}
