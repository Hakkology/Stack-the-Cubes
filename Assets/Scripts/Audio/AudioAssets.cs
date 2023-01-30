using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAssets : MonoBehaviour
{
    // List of Sounds to be Played
    public List<Sound> ListofSounds = new List<Sound>();

    // Instance for AudioAssets
    public static AudioAssets instance;

    // At start of the game
    private void Awake() {

        //// Just two make sure audiomanager is not spawned twice, singleton for audioasset manager
        /// No longer necessary to make a singleton, scene change is not implemented.
        //if (instance = null) {
        //    instance = this;
        //}
        //else {
        //    Destroy(gameObject);
        //}

        foreach (Sound audioClip in ListofSounds) {

            // assigning audiosource components to Sound Class
            audioClip.audioSource = gameObject.AddComponent<AudioSource>();
            audioClip.audioSource.clip = audioClip.audioClip;

            // volume and pitch components added, loop boolean added
            audioClip.audioSource.volume = audioClip.volume;
            audioClip.audioSource.pitch = audioClip.pitch;
            audioClip.audioSource.loop = audioClip.loop;

        }    
    }

    private void Start() {

        PlaySound(SoundNames.BackgroundMusic);

    }

    // play sound files
    public void PlaySound (SoundNames soundNames) {

        // find the sound where the name of sound is the same as enum name of sound
        Sound sound = ListofSounds.Single(sound => sound.nameofSound == soundNames);

        // if sound is null, to avoid errors
        if (sound == null) {

            Debug.LogWarning("Sound: " + sound.nameofSound + " not found!");
            return;
        }

        // Play that sound
        sound.audioSource.Play();

    }

    // play sound files
    public void StopSound(SoundNames soundNames) {

        // find the sound where the name of sound is the same as enum name of sound
        Sound sound = ListofSounds.Single(sound => sound.nameofSound == soundNames);

        // Play that sound
        sound.audioSource.Stop();

    }

    //// play music files
    //public void PlayMusic(SoundNames soundNames) {

    //    // find the sound where the name of sound is the same as enum name of sound
    //    Sound sound = (Sound)ListofSounds.Where(sound => sound.nameofSound == soundNames);

    //    // Play that sound
    //    sound.audioSource.play
    //}



}
