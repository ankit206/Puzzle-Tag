using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    // player postion.
    public Transform player; 
    // Offset to position the camera above the player.
    public Vector3 offset = new Vector3(0, 10, -10); 
    // Speed for smooth camera movement.
    public float smoothSpeed = 0.125f;

    // follow the player .
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset; 
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); 
            transform.position = smoothedPosition;

            transform.LookAt(player.position); 
        }
    }
}
