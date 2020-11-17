using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    // Augmentation de la vie en ramassant un coeur 
    public int healthPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
        }
    }
}
