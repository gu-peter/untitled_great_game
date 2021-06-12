using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    // player movement
    Vector2 movement = new Vector2();
    Vector2 mouse = new Vector2();
    public float speed = 10.0f;
    private Rigidbody2D body;

    // camera
    public Camera cam;


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
        Rotate(mouse);
    }

    void GetInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // moves the player according to keyboard input
    void Move(Vector2 movement)
    {
        //body.velocity = movement * speed;
        body.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);
    }

    // rotates the orientation of the player according to mouse position
    void Rotate(Vector2 mousePos)
    {
        // looking direction
        Vector2 lookDir = mouse - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
        body.rotation = angle;
    }


}
