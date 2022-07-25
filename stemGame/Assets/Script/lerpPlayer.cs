using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpPlayer : MonoBehaviour
{
    private GameObject player;

    private Vector3 direction;

    public float speed = 0.2f;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        direction = player.transform.position - transform.position;
        rositionTo();
    }

    void rositionTo()
    {
        Quaternion quaternion = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, Time.deltaTime * speed);

    }
}
