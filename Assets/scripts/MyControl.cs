using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MyControl : MonoBehaviour
{
    protected Joystick joystick;
    private float speed = 10.0f;
    private bool IsDead = false;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
            return;

        var rigidbody= GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * speed,joystick.Vertical * speed, rigidbody.velocity.y );

    }

    public void SetSpeed(int modifier)
    {
       speed = 10.0f + modifier;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Death();
        }
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    void Death()
    {
        IsDead = true;
        GetComponent<Score>().OnDeath();
    }

}

