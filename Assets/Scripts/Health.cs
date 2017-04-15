using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    public void TakeDamage(int amount)
    {
        if (isServer)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log("Dead!");
            }
        }
    }
    void OnChangeHealth(int health)
    {
        player.FlashDamage();
        Debug.Log("HEALTH = " + health);
    }

}