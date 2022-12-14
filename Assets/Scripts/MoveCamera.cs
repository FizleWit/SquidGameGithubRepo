using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
     Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

       // turn.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

       // xRotation -= turn.y;

       // xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      //  transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);

    }
}
