using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(AudioSource))]
    public class footsteps : MonoBehaviour
    {

        AudioSource audioSource;

        CharacterController controller;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (controller.isGrounded == true && controller.velocity.magnitude > 1f && audioSource.isPlaying == false)
            {
                audioSource.volume = Random.Range(0.8f, 1f);
                audioSource.pitch = Random.Range(0.8f, 1.1f);
                audioSource.Play();
            }
        }
    }
