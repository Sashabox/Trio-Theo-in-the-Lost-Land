using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
	private AudioClip menuMusic;

    [SerializeField]
	private AudioClip levelMusic;

    [SerializeField]
    private AudioSource source;

    private static AudioManager instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }
        
    }

    protected virtual void Start()
    {
        PlayMenuMusic();
    }

    public static void PlayMenuMusic()
	{
		if (instance != null)
        {
			if (instance.source != null)
            {
				instance.source.Stop();
				instance.source.clip = instance.menuMusic;
				instance.source.Play();
			}
		}
        else
        {
			Debug.LogError("Unavailable AudioManager component");
		}
	}

    public static void PlayGameMusic()
	{
		if (instance != null)
        {
			if (instance.source != null)
            {
				instance.source.Stop();
				instance.source.clip = instance.levelMusic;
				instance.source.Play();
			}
		}
        else
        {
			Debug.LogError("Unavailable AudioManager component");
		}
	}
}
