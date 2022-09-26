using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;


    [Header("Taking Damage")]
    [SerializeField] AudioClip takingDamageClip;
    [SerializeField] [Range(0f, 1f)] float takingDamageVolume = 1f;

    static AudioPlayer instance;


    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            Play(shootingClip, shootingVolume);
        }
    }

    public void PlayTakingDamageClip()
    {
        Play(takingDamageClip, takingDamageVolume);
    }

    private void Play(AudioClip clip , float volume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
