using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    [SerializeField] private List<Sound> sounds;

    private void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = audioMixerGroup;
        }
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if(sound == null)
        {
            return;
        }
        if(sound.source == null)
        {
            return;
        }
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if(sound == null)
        {
            return;
        }
        if(sound.source == null)
        {
            return;
        }
        sound.source.Stop();
    }

    public void Pause(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if(sound == null)
        {
            return;
        }
        sound.source.Pause();
    }

    public void Mute(string name, bool pos)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if(sound == null)
        {
            return;
        }
        if(pos)
        {
            sound.source.mute = true;
        }
        else
        {
            sound.source.mute = false;
        }
    }
}
