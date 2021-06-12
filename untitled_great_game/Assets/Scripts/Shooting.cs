using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bodyBullet = bullet.GetComponent<Rigidbody2D>();
        bodyBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
