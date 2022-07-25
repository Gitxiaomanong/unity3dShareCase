using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullt : MonoBehaviour
{
    private Rigidbody rigidbody;

    private float bulltSpeed = 100f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * bulltSpeed;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemy>().startHp(5, other.gameObject);
        }
        Destroy(gameObject);
        Destroy(gameObject, 2f);
    }
}
