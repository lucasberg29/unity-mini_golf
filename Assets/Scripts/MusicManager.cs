using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource currentSongPlaying;

    public AudioClip[] songs;

    private AudioSource musicSource;

    private bool isSwitchingSong;
    private bool isLoweringVolume;
    private bool isRaisingVolume;

    public float songSwitchingSpeed;

    private int nextSongIndex = 0;

    public bool isMusicPlaying = true; 

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        musicSource = GetComponent<AudioSource>();
        PlaySong(0);
    }

    void Update()
    {
        if (!isMusicPlaying)
        {
            musicSource.Stop();
            return;
        }

        if (isSwitchingSong)
        {
            if (isLoweringVolume)
            {
                if (musicSource.volume <= 0.0f)
                {
                    isLoweringVolume = false;
                    isRaisingVolume = true;
                    PlaySong(nextSongIndex);
                }
                else
                {
                    musicSource.volume -= songSwitchingSpeed * Time.deltaTime;
                }
            }
            else if (isRaisingVolume)
            {
                if (musicSource.volume >= 1.0f)
                {
                    isRaisingVolume = false;
                    isSwitchingSong = false;
                }
                else
                {
                    musicSource.volume += songSwitchingSpeed * Time.deltaTime;
                }
            }
        }
    }

    private void PlaySong(int index)
    {
        musicSource.clip = songs[index];
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayVictory()
    {

    }

    public void PlayNextSong(int index)
    {
        if (index < songs.Length)
        {
            nextSongIndex = index;
            isSwitchingSong = true;
            isLoweringVolume = true;
            //musicSource.clip = songs[index];
            //musicSource.Play();
        }
    }
}
