using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour

{
    // L'ennemi fait des dommages 
    public int damageOnCollision = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
