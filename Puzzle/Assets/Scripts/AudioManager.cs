using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Awake ()
    {
        
        if(GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // EVITAMOS QUE SE DESTRUYA EL AUDIOMANAGER AL CAMBIAR DE ESCENA
            DontDestroyOnLoad(gameObject);
        }

		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            // PASAR EL CLIP Y SUS OPCIONES DEL AUDIO SOURCE AL SCRIPT SOUNDS CON NUESTROS AJUSTES
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.audioMixer;
        }
    }
    
    public void Play(string name)
    {
        // BUSCAMOS EN EL ARRAY DE SONIDOS EL SONIDO CON EL NOMBRE QUE QUEREMOS
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "no se encuentra");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        // BUSCAMOS EN EL ARRAY DE SONIDOS EL SONIDO CON EL NOMBRE QUE QUEREMOS
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "no se encuentra");
            return;
        }

        s.source.Stop();
    }
}
