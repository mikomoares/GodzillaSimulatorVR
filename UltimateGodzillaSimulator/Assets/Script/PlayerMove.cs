using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMove : MonoBehaviour
{
 
 
    CharacterController Controller;
 
    public float Speed, gravity;
 
    public Transform Cam;
 
 
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<CharacterController>().isTrigger = true;

        Controller = GetComponent<CharacterController>();
 
    }
 
    // Update is called once per frame
    void Update()
    {
 
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
 
        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;

        if(this.transform.parent != null || Controller.isGrounded){
            gravity = 0f;
        }   
        else{
            gravity -= 9.81f * Time.deltaTime;
        }

        Controller.Move(Movement + new Vector3(0f, gravity, 0f));
 
        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().sensivity * Time.deltaTime);
 
 
            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;
 
            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
 
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Quebrador" || other.gameObject.tag == "Hand" ){
            gravity = 0f;
        }
        else{

        }
    }
 
}
 