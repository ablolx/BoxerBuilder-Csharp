using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerAttack : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(10); // Apply damage amount (adjust as needed)
                }
            }
        }
    }
}
