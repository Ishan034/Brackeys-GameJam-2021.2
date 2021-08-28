using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    public string mainMenuMusic;
    public string gameMusic;

    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += ChangeMusic;

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
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

    private void ChangeMusic(Scene from, Scene to)
    {
        Instance.StopPlayAll();
        if (to.buildIndex == 0)
        {
            Instance.Play(mainMenuMusic);
        }
        else if (to.buildIndex == 1)
        {
            Instance.Play(gameMusic);
        }
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

    public void StopPlayAll()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.Stop();
        }
    }
}
