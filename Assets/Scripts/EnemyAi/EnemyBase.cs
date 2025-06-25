using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Movement speed.
    public float speed = 3f;
    public Transform[] waypoints;
    public float currentDistance;
    public int currentWaypoint;
   

    void Update()
    {
       MoveTowards(waypoints[currentWaypoint].position);
    }

    // Moves the enemy towards a Waypoint.
    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,speed* Time.deltaTime );
        Debug.Log("moving Enamy");
        if (checkDistance(targetPosition) <.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
    // cheak distancec between waypoint
    public float checkDistance(Vector3 targetPosition)
    {
        currentDistance = Vector3.Distance(transform.position, targetPosition);
        return currentDistance;
    }
}
