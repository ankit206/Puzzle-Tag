using UnityEngine;

public class PlayerController : MonoBehaviour
{
       // Movement speed.
       public float speed = 5f; 
       void Update()
       {
           MovePlayer();
       }
       // Player moment Logic
       private void MovePlayer()
       {
           float moveHorizontal = Input.GetAxis("Horizontal"); 
           float moveVertical = Input.GetAxis("Vertical");
   
           Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
           move = transform.TransformDirection(move); 
           transform.position += move * (speed * Time.deltaTime); 
       }
}
