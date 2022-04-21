using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    static private AudioClip successAction;
    static private AudioClip successObject;
    static private AudioClip error;
    static private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        successAction = Resources.Load<AudioClip>("audio/success");
        successObject = Resources.Load<AudioClip>("audio/success2");
        error = Resources.Load<AudioClip>("audio/fail");
    }

    static public void playSuccessActionSound()
    {
        audioSource.PlayOneShot(successAction, 0.7F);
    }

    static public void playSuccessObjectSound()
    {
        audioSource.PlayOneShot(successObject, 1F);
    }

    static public void playErrorSound()
    {
        audioSource.PlayOneShot(error, 1F);
    }
}
