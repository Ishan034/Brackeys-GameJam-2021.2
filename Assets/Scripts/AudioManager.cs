using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
        }
    }

    private void Start()
    {
        Play("Track_1"); // Play at start
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.Name == name);
        if (sound == null)
        {
            Debug.Log("Could not find sound: " + name);
            return;
        }
        sound.source.Play();
    }
}
