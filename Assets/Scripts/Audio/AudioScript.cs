using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// names of sound files to be called
public enum SoundNames {
    CoinCollect,
    CurtainSound,
    EndofChapter,
    EndofGame,
    BackgroundMusic,
    WalkingSounds
}

[System.Serializable]
public class Sound
{
    // Name of Sound
    public SoundNames nameofSound;

    // Audioclip property variable
    public AudioClip audioClip;

    // Adding AudioSource Component
    [HideInInspector] 
    public AudioSource audioSource;

    // Audio volume setting
    [Range(0f, 1f)] 
    public float volume;

    // Audio pitch setting
    [Range(0.1f, 3f)]
    public float pitch;

    // Loop setting
    public bool loop;

}
