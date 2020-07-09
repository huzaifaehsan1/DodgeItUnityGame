using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyControl : MonoBehaviour
{
    protected Joystick joystick;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody= GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 10f,joystick.Vertical * 10f, rigidbody.velocity.y );

    }
}
