using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private Transform head;
    private Transform body;
    private Rigidbody rigidbody;

    private float moveSpeed=400;
    private float moveSpeed1 = 20;
    void Start()
    {
        head = transform;
        body = transform.parent;
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float hroitzonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hroitzonal, 0, vertical);
        if(dir != Vector3.zero)
        {
            body.Translate(dir * Time.deltaTime * moveSpeed1);
        }
        float mousex = Input.GetAxis("Mouse X");
        if(mousex != 0)
        {
            body.Rotate(Vector3.up, mousex * moveSpeed * Time.deltaTime);
        }
        float mousey = Input.GetAxis("Mouse Y");
        if (mousey != 0)
        {
            head.Rotate(Vector3.left, mousey * moveSpeed * Time.deltaTime);
        }
        if(Vector3.Angle(body.forward, head.forward) > 60)
        {
            head.Rotate(Vector3.left, -mousey * moveSpeed * Time.deltaTime);
        }
    }
}
