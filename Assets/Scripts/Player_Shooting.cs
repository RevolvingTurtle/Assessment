using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // Where the bullet will be instantiating from
    public float bulletSpeed = 20f; // Speed of bullet
    private Player_Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //Checking if the player has pressed the F key, and if so it will run the shoot script below
        {
            Shoot();
        }
    }

    void Shoot () 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Instantiates the bullet prefab a the firepoint and apply rotation
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 fireDirection = playerMovement.facingRight ? Vector2.right : Vector2.left; // Applies force to the bullet prefab based on which direction the tank is facing
        rb.AddForce(fireDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}
