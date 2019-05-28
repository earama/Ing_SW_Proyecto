using UnityEngine.Audio;
using UnityEngine;
using System;


/*Aqui entra la logica de como funciona el administrador de sonido, se colocan los distintos 
"audio source" en un array y se guardan para luego llamarlos desde los demas scripts.  */
public class AudioManager : MonoBehaviour
{

    public Sound [] sounds; //libreria de sonidos

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource> ();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name) // metodo que se llama de los otros scripts para escuchar el sonido.
    {
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        if(s==null)
        {
            Debug.LogWarning("Sound" + name + "not found");
            return;
        }
        s.source.Play();
    }
}