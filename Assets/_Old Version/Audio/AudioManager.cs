using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{public static AudioManager Instance { get; private set; }

    public Sound[] uniqueSounds;

    public SoundGroup[] soundGroups;

    [SerializeField] AudioSource musicAudioSource;

    private void Awake()
    {
        SingletonPattern();

        CreateAudioSources(ref uniqueSounds);

        foreach (SoundGroup sg in soundGroups)
        {
            CreateAudioSources(ref sg.soundOptions);
        }
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void CreateAudioSources(ref Sound[] sounds)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlayUniqueSound(string name)
    {
        Sound s = Array.Find(uniqueSounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayUniqueSoundLoop(string name)
    {
        Sound s = Array.Find(uniqueSounds, sound => sound.name == name);
        s.source.loop = true;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopUniqueSoundLoop(string name)
    {
        Sound s = Array.Find(uniqueSounds, sound => sound.name == name);
        s.source.loop = false;
        s.source.Stop();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void PlaySoundGroup(int groupIndex)
    {
        int maxOption = soundGroups[groupIndex].soundOptions.Length;
        int selectedOption = UnityEngine.Random.Range(0, maxOption);
        Sound s = soundGroups[groupIndex].soundOptions[selectedOption];

        s.source.Play();
    }
}

[System.Serializable]
public class SoundGroup
{
    public string name;
    public Sound[] soundOptions;
}