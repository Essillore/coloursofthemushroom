using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform target;
    public Transform player;

    public float rotationX = 0f;
    public float rotationY = 0f;
    public float rotationZ = 0f;

    public float sensitivity = 10f;
    public float orbitDamping = 20f; //10

    public float distanceFromPlayer = 50.0f;
    public float cameraHeight = 2.0f;

    public float movementSmoothing = 0.4f; // 0.1

    public bool endState = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player);
        Cursor.lockState = CursorLockMode.Confined;

        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

       //  rotationY = target.transform.rotation.eulerAngles.y;
        rotationY += mouseX * sensitivity;
        rotationX += mouseY * -1 * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -50f, 50f);

        rotationZ = target.transform.rotation.eulerAngles.z;

        // Calculate the position of the camera in a circular motion around the player
        
        Vector3 cameraPosition = new Vector3(
        distanceFromPlayer * -Mathf.Sin(rotationY * Mathf.Deg2Rad) * Mathf.Cos(rotationX * Mathf.Deg2Rad),
        cameraHeight,
        distanceFromPlayer * -Mathf.Cos(rotationY * Mathf.Deg2Rad) * Mathf.Cos(rotationX * Mathf.Deg2Rad)
        );
       

        if (endState == false)
        {

            // Update the position of the camera relative to the player
            // transform.position = target.transform.position + cameraPosition;

            // Smooth camera movement towards target position
            // transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraPosition, movementSmoothing);
            transform.position = Vector3.Lerp(transform.position, target.transform.position, movementSmoothing);


            Quaternion QT = Quaternion.Euler(rotationX, rotationY, rotationZ);
            transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
        }
    }
}