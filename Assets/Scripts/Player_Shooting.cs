using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // Where the bullet instantiates from
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        Debug.Log ("Firepoint position at shoot: " +firePoint.position);   

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 fireDirection = playerMovement.facingRight ? Vector2.right : Vector2.left;
        rb.AddForce(fireDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}
