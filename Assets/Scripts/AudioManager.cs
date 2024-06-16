using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixerGroup mixerGroup;
    public static AudioManager instance;
    private void Start()
    {
        if (this.name == "AudioManagerMenu")
        {
            FindObjectOfType<AudioManager>().Play("MenuTheme");
            FindObjectOfType<AudioManager>().Play("Wind");
        }

        if (this.name == "AudioManagerScene1")
        {
            FindObjectOfType<AudioManager>().Play("Epic");

        }
        if (this.name == "AudioManagerScene2")
        {
            FindObjectOfType<AudioManager>().Play("End");

        }
        if (this.name == "AudioManagerScene3")
        {
            FindObjectOfType<AudioManager>().Play("End");

        }
        if (this.name == "AudioManagerScene4") // Replace with your actual scene name
        {
            //StartCoroutine(PlayRoarAndChase());
            FindObjectOfType<AudioManager>().Play("Chase");
        }
    }
    void Awake()
    {
        //presist scenes
        /*if (instance == null)// no audio manager in scene
        {
            instance = this;
          
        }


        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);*/
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mixerGroup;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    private IEnumerator PlayRoarAndChase()
    {
        Play("Roar");
        yield return new WaitForSeconds(3f);
        Play("Chase");
    }

}