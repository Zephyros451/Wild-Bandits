using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource loseSound;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource background;

    [Space, SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager.PlayerLose += PlayLoseSound;
    }

    private void PlayLoseSound()
    {
        background.Pause();
        loseSound.Play();
    }

    public void UnpauseBackground()
    {
        background.UnPause();
        loseSound.Stop();
    }
}
