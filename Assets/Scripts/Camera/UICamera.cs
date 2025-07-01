using UnityEngine;

public class UICamera : MonoBehaviour
{
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }
    // make health ui to face camera 
    void LateUpdate()
    {
        if (mainCam != null)
        {
            transform.LookAt(transform.position + mainCam.transform.rotation *Vector3.forward, mainCam.transform.rotation * Vector3.up);
        }
    }
}
