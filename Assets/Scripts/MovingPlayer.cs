using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovingPlayer : MonoBehaviour
{
    public CharacterController playerController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;

    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    PhotonView playerViewer;

    // Start is called before the first frame update
    void Start()
    {
    
    playerViewer = GetComponent<PhotonView>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(playerViewer.IsMine)
        {
           // ProcessInputs();
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
        }  
    }
}