using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController characterCollider;
    private bool isCrouching = false;
    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching == false)
            {
                characterCollider.height = 1.9f;
                isCrouching = true;
            }
            else
            {
                characterCollider.height = 3.8f;
                isCrouching = false;
            }
        }

        
    }
}
