using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] wayPoints; // By combining static and public, you create a globally accessible array that can be accessed and utilized from any other script in your project without needing an instance of the Waypoints class.

    private void Awake()
    {
        // We load our wayPoints array with the number of waypoints in the scene (based on the number of child objects)
        // Each element in the array represents a waypoint's position, rotation, and scale.
        wayPoints = new Transform[transform.childCount];

        // Loop through each child waypoint and assign its transform component to the corresponding element in the array.
        for (int i = 0; i < wayPoints.Length; i++) // Loop through those 17 waypoints
        {
            
            wayPoints[i] = transform.GetChild(i); // Stores the transform component of each child to the wayPoints array we just initialized
        }
    }
}

/* To access the Transform data of the waypoints from another script:

- Declare a variable of type Vector3 or Quaternion, depending on which component of the transform you want to access (e.g., position, rotation).
- Use the class name Waypoints because it's the class you defined.
- Access the wayPoints array using Waypoints.wayPoints.
- Use the index of the desired waypoint within the array (e.g., [0] for the first waypoint).
- Access the specific component of the transform (e.g., .position for position, .rotation for rotation, .localScale for scale).

Exmaples:

        // Access the position of the first waypoint
        Vector3 firstWaypointPosition = Waypoints.wayPoints[0].position;

        // Access the rotation of the second waypoint
        Quaternion secondWaypointRotation = Waypoints.wayPoints[1].rotation;

        // Access the scale of the third waypoint
        Vector3 thirdWaypointScale = Waypoints.wayPoints[2].localScale;

        // Modifying the scale of the second waypoint
        Waypoints.wayPoints[1].localScale = new Vector3(2.0f, 2.0f, 2.0f);

*/