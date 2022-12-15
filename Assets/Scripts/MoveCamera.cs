using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class MoveCamera : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    public Transform playerBody;
    Camera Cam;
    float xRotation = 0f;
    // Start is called before the first frame update

   PhotonView playerViewer;

    void Start()
    {
        Cam = GetComponent<Camera>();
     playerViewer = GetComponentInParent<PhotonView>();
     Cursor.lockState = CursorLockMode.Locked;   
     if(!playerViewer.IsMine)
     {
        Cam.enabled = false;
     }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerViewer.IsMine)
        {
          //  ProcessInputs();
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        }
       

        //turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

       // turn.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

       // xRotation -= turn.y;

       // xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      //  transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);

    }
}

