using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerMovement : MonoBehaviour
{
    private bool isLightweight = false;
    private bool isSprinting = false;

    AudioSource audioSource;

    public CharacterController controller;

    public float basespeed = 6f;
    public float doublespeed = 12f;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
 
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }



    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "lightweight")
        {
            isLightweight = true;
            jumpHeight = 7f;
        }

    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded == true && controller.velocity.magnitude > 1f && audioSource.isPlaying == false)
        {
            audioSource.volume = Random.Range(0.8f, 1f);
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.Play();
        }


        if (Input.GetKey(KeyCode.LeftShift) && controller.height == 3.8f)
        {
            speed = doublespeed;
        }
        else
        {
            speed = basespeed;
        }
        //if (Input.GetKeyDown(KeyCode.L))
        //{
         //   jumpHeight = 7f;
        //}




    }
}
