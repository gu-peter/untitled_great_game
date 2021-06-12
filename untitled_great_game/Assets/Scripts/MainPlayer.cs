using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    // player movement
    Vector2 movement = new Vector2();
    public float speed = 10.0f;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Move(movement);
    }

    void GetInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void Move(Vector2 movement)
    {
        //body.velocity = movement * speed;
        body.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);
    }
}
