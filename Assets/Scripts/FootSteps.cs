using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Use this for initialization
    GameObject player;
    CharacterController cc;
    AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        if (cc.isGrounded == true && cc.velocity.magnitude == 0f && audioSource.isPlaying == true)
        {
            audioSource.Stop();
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

}
