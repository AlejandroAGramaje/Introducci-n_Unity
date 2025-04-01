using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    void Awake()
    {
        // Evita que se destruya entre escenas (si lo deseas)
        DontDestroyOnLoad(gameObject);

        // Inicia la m�sica si no est� ya sonando
        if (!music.isPlaying)
            music.Play();
    }
}

