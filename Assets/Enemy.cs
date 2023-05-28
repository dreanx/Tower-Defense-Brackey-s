using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; // The speed at which the enemy moves

    private Transform target; // The target waypoint the enemy is moving towards
    private int wavepointIndex = 0; // Index of the current waypoint

    private void Start()
    {
        target = Waypoints.wayPoints[wavepointIndex]; // Set the initial target waypoint to the first waypoint in the Waypoints array
    }

    private void Update()
    {
        // Calculate the direction vector3 from the enemy's current position to the target waypoint
        Vector3 direction = target.position - transform.position;

        // Every frame, move the enemy in the direction of the target waypoint at a constant speed by normalizing
        // and using Time.deltaTime to make the movement frame rate independent
        // Applying the translation relative to the world coordinate system
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Check if the enemy has reached the target waypoint
        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            // If the distance is small enough, get the next waypoint
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        // Check if the current waypoint index is the last waypoint
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            // If it is the last waypoint, destroy the enemy object and exit the method
            Destroy(gameObject);
        }
        else
        {
            // Increment the waypoint index to move to the next waypoint
            wavepointIndex++;
            // Set the target to the next waypoint
            target = Waypoints.wayPoints[wavepointIndex];
        }
    }
}