using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hor;
    private float ver;

    private Rigidbody rigidbody;

    private bool isJump;
    private bool isAudio;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0&& isAudio)
        {
            if (!AudioManager.Instace.source.isPlaying)
            {
                AudioManager.Instace.playAudio(GameManager.Instace.gameConfg.clip);
            }
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            if (isJump)
            {
                jump();
            }
        }

       
    }
    //角色跳
    private void jump()
    {
       rigidbody.velocity = Vector3.up * 5;
        AudioManager.Instace.playAudio(GameManager.Instace.gameConfg.clip1);
        isAudio = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plane")
        {
            isJump = true;
            isAudio = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        isJump = false;
    }
}
