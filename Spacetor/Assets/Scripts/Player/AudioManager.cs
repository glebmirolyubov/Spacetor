using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip MainTrack;

    public void ChangeSoundtrackToMain()
    {
        GetComponent<AudioSource>().clip = MainTrack;
        GetComponent<AudioSource>().Play();
    }
}
