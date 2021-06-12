using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    // main player
    private GameObject target;

    // movement
    Vector2 movement_direction = new Vector2();
    float speed; 

    // physics
    Rigidbody2D enemyBody;
    new BoxCollider2D collider = new BoxCollider2D();

    // health
    int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        collider = gameObject.GetComponent<BoxCollider2D>();
        enemyBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        speed = Random.Range(2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    // turns to player and chases him
    void ChasePlayer()
    {
        movement_direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(movement_direction.y, movement_direction.x) 
            * Mathf.Rad2Deg - 90.0f;
        enemyBody.rotation = angle;
        movement_direction.Normalize();
        enemyBody.MovePosition((Vector2)transform.position + 
            movement_direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // determine the bounce behaviour of simple enemy
        if(collision.gameObject.tag == "Bullet")
        {
            EnemyHealth();
            collider.sharedMaterial = new PhysicsMaterial2D()
            {
                bounciness = 0.3f
            };
        } else
        {
            collider.sharedMaterial = new PhysicsMaterial2D()
            {
                bounciness = 0.0f
            };
        }
    }

    void EnemyHealth()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        health--;
    }
}
