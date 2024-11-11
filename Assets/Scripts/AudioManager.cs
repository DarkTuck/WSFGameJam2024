using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

    [SerializeField] public EventReference Horror;
    [SerializeField] public EventReference Zerwanie;
    [SerializeField] public EventReference Uwu;
    [SerializeField] public EventReference Footstep;
    [SerializeField] public EventReference Slash;
    [SerializeField] public EventReference Jumpscare;


    public static AudioManager instance { get; private set; }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("O kurwa ni dziala, wincej niz jeden audio manager w scenie");
        }
        instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector2 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
        
    }
    
    public void PlayLoop(EventReference sound, Vector2 worldPos)
    {
        FMOD.Studio.EventInstance instance = RuntimeManager.CreateInstance(sound);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(worldPos));
        instance.start();
        instance.release(); // Release the instance immediately to avoid leaks
    }
}
