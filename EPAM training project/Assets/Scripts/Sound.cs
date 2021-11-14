using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField] public string name;
    [SerializeField] public AudioClip clip;
    [Range(0f, 1f)]
    [SerializeField] public float volume;
    [Range(0.1f, 3f)]
    [SerializeField] public float pitch;
    [SerializeField] public bool loop;
    [HideInInspector] public AudioMixerGroup audioMixerGroup;
    [HideInInspector] public AudioSource source;
}
