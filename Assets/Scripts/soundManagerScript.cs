using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManagerScript : MonoBehaviour {

    public static AudioClip buttonClick;
    public static AudioClip jump;
    public static AudioClip menu;
    public static AudioClip gameplay;
    public static AudioClip gameover;

    private static AudioSource audioSrcSfx;
    private static AudioSource audioSrcMusic;

    private static float sfxLevel = 0.9f;
    private static float musicLevel = 0.4f;

    private void Start()
    {
        buttonClick = Resources.Load<AudioClip>("buttonClick");
        jump = Resources.Load<AudioClip>("jump");
        menu = Resources.Load<AudioClip>("menu");
        gameplay = Resources.Load<AudioClip>("gameplay");
        gameover = Resources.Load<AudioClip>("gameOver");

        AudioSource[] sources = GetComponents<AudioSource>();
        audioSrcSfx = sources[0];
        audioSrcMusic = sources[1];

        audioSrcSfx.volume = sfxLevel;
        audioSrcMusic.volume = musicLevel;
    }

    public void Update()
    {

    }

    public static void StopMusic()
    {
        audioSrcMusic.Stop();
    }

    public static void StopSfx()
    {
        audioSrcSfx.Stop();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "buttonClick":
                if(buttonClick!=null)   //to avoid any NullReferenceException error
                    audioSrcSfx.PlayOneShot(buttonClick);
                break;
            case "jump":
                if (jump != null)
                    audioSrcSfx.PlayOneShot(jump);
                break;
            case "gameOver":
                if (jump != null)
                    audioSrcSfx.PlayOneShot(gameover);
                break;
            case "gamePlay":
                audioSrcMusic.loop = true;
                audioSrcMusic.clip = gameplay;
                audioSrcMusic.Play();
                break;
            case "menu":
                audioSrcMusic.loop = true;
                audioSrcMusic.clip = menu;
                audioSrcMusic.Play();
                break;
            default:
                break;
        }
        
    }
}
