using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject healthBarPrefab; // Reference to the health bar prefab
    private GameObject healthBarInstance;

    private void Start()
    {
        currentHealth = maxHealth;
        // Instantiate the health bar prefab and parent it to the enemy's head
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2.5f, Quaternion.identity, transform);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death animation
        GetComponent<Animator>().SetTrigger("Die");
        // Destroy the health bar instance
        Destroy(healthBarInstance);
        // Destroy the enemy after the death animation duration
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
