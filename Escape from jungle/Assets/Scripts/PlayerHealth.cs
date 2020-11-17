using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    //Représente la santé du joueur
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //Permet de tester la barre de vie 
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void HealPlayer(int amount)
    {
        //Si le joueur ramasse un coeur 
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        //le joueur prend des dégats
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            //Si le joueur n'a plus de PV 
            if(currentHealth <= 0)
            {
                Die();
                return;
            }
            //Le joueur devient invincible quelques instants
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        //On supprime l'instance du joueur
        PlayerMovement.instance.enabled = false;
        //Plus rien ne peut pousser le joueur (exemple ennemi)
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        //Le joueur devient invisible
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        //On crée une insatnce du joueur 
        PlayerMovement.instance.enabled = true;
        // Qui peut être pousée 
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        //Joueur visible 
        PlayerMovement.instance.playerCollider.enabled = true;
        //Le joueur a le nombre de PV maximum 
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            //Lorsque le joueur est invincible, il clignote quelques instants 
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
