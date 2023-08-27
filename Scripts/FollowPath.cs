using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePathFollower : MonoBehaviour
{
    public Transform[] waypoints;   // Waypoints to follow
    public float speed = 5.0f;      // Movement speed
    public Animator animator;       // Reference to the Animator component
    public RawImage gameOverImage;  // Reference to the Game Over Raw Image

    private int currentWaypointIndex = 0;
    private hsb_enemy enemyScript;  // Reference to the hsb_enemy script

    private void Awake()
    {
       // animator = GetComponent<Animator>(); // Get the Animator component
        enemyScript = GetComponent<hsb_enemy>(); // Get the hsb_enemy script
        gameOverImage.gameObject.SetActive(false); // Hide the game over image initially
    }

    private void Update()
    {
        if (waypoints.Length == 0 || enemyScript.isdead == true)
            return;

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if close enough to the current waypoint
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Check if the enemy reached the final waypoint
            if (currentWaypointIndex == 0)
            {
                DisplayGameOver();
            }
        }

        // Update the isWalking parameter of the animator
        bool isMoving = Vector3.Distance(transform.position, targetPosition) > 0.05f;
        //animator.SetBool("isWalking", isMoving);
    }

    void DisplayGameOver()
    {
        gameOverImage.gameObject.SetActive(true); // Show the game over image
    }
}
