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
 
    void Start()
    {
        speed = 8f;
        //NAO TIRAR=======================
        Cam = GameObject.Find("Camera3rd").transform;
        CameraMove.lookAt = this.gameObject.transform;
        //================================
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
 
        float Horizontal = Input.GetAxis("Horizontal") * speed ;
        float Vertical = Input.GetAxis("Vertical") * speed ;
 
        Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;

        Movement.y = rigidBody.velocity.y;
        rigidBody.velocity = Movement;

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().sensivity * Time.deltaTime);
 
            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;
 
            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
 
        }
    }

    void FixedUpdate(){

    }


 
}
 