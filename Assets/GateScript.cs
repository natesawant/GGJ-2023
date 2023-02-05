using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : ActivatableInterface
{
    public GameObject opened, closed;
    public AudioClip openNoise, closeNoise;
    AudioSource audioSrc;

    private void Start()
    {
        audioSrc= GetComponent<AudioSource>();
    }
    public override void Activate()
    {
        opened.SetActive(true);
        closed.SetActive(false);
        audioSrc.clip = openNoise;
        audioSrc.Play();
    }

    public override void Deactivate()
    {
        opened.SetActive(false);
        closed.SetActive(true);
        audioSrc.clip = closeNoise;
        audioSrc.Play();
    }
}
