using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerReal : MonoBehaviour
{   

    //Coponents From Moving Player 
    CharacterController playerController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;

    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //Componets from Move Camera
    
    public float MouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Components from Move Camera 
        Cursor.lockState = CursorLockMode.Locked;
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Components from Moving Player
        if(Input.GetButtonDown("Jump") )
        {
            velocity.y = jumpHeight;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        playerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);

        //Components from Move Camera
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
