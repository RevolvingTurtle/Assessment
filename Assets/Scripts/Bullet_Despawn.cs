using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_Despawn : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the bullet before it is destroyed
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); // Destroys the bullet after a certain amount of time
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Destroy(gameObject); // Destroys the bullet and enemies on impact

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
