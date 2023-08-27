using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hsb_enemy : MonoBehaviour
{
    public Animator animator;
    public int maxhealth = 100;
    public int currenthealth;
    public bool isdead;

    private float despawnDelay = 5.0f; // Delay before despawning

    void Start()
    {
        currenthealth = maxhealth;
    }

    public void takedamage(int damage)
    {
        currenthealth -= damage;
        animator.SetTrigger("hurt");
        if (currenthealth <= 0)
            Die();
    }

    void Die()
    {
        isdead = true;
        Debug.Log("Enemy Died");
        animator.SetBool("dead", true);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;

        StartCoroutine(DespawnAfterDelay());
    }

    IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(despawnDelay);

        // After the delay, despawn the enemy
        Despawn();
    }

    void Despawn()
    {
        // Perform any cleanup or final actions here

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
