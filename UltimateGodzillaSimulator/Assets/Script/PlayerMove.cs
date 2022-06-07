using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMove : MonoBehaviour
{
    CharacterController Controller;
    private float speed;
    public Transform Cam;
    private Rigidbody rigidBody;
    private Vector3 Movement;
    public bool isGrounded;
    public bool canMove;
    public bool isDropped;

 
    void Start()
    {
        speed = 8f;
        //NAO TIRAR=======================
        Cam = GameObject.Find("Camera3rd").transform;
        CameraMove.lookAt = this.gameObject.transform;
        //================================
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        isGrounded = true;
        canMove = true;
        isDropped = false;
    }

    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed ;
        float Vertical = Input.GetAxis("Vertical") * speed ;

        if(this.transform.parent != null){
            if(this.transform.parent.tag == "Hand"){
                canMove = false;
                rigidBody.freezeRotation = false;

            }
        }
        else if((Vertical != 0 || Horizontal != 0) && isDropped){
            canMove = true;
            isGrounded = true;
            rigidBody.freezeRotation = true;
        }
 
        if(isGrounded) Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        else Movement = new Vector3(0f,0f,0f);
        
        Movement.y = rigidBody.velocity.y;
        if(canMove)rigidBody.velocity = Movement;

        if (Movement.magnitude != 0f && canMove)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().sensivity * Time.deltaTime);
 
            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;
 
            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground"){
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground"){
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (!canMove) isDropped = true;
    }

}
 