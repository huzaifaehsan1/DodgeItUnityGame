using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private GameObject circle, dot;
    private Rigidbody2D rb;
    public float moveSpeed;
    private Touch oneTouch;
    private Vector2 touchPosition;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circle.SetActive(false);
        dot.SetActive(false);
        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            oneTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);
            switch (oneTouch.phase)
            {
                case TouchPhase.Began:
                    circle.SetActive(true);
                    dot.SetActive(true);

                    circle.transform.position = touchPosition;
                    dot.transform.position = touchPosition;
                    break;
                case TouchPhase.Stationary:
                    MovePlayer();
                    break;
                case TouchPhase.Moved:
                    MovePlayer();
                    break;
                case TouchPhase.Ended:
                    circle.SetActive(false);
                    dot.SetActive(false);

                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }
    private void MovePlayer()
    {
        dot.transform.position = touchPosition;

        dot.transform.position = new Vector2(
            Mathf.Clamp(dot.transform.position.x,
            circle.transform.position.x - 0.8f,
            circle.transform.position.x + 0.8f),
            Mathf.Clamp(dot.transform.position.x,
            circle.transform.position.y - 0.8f,
            circle.transform.position.y + 0.8f));

        moveDirection = (dot.transform.position - circle.transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }
}
    