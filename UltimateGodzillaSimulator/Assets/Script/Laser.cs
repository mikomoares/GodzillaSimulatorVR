using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smoke;
    public Hand hand;
    private GameObject laser;

    void Start(){
        laser = transform.GetChild(0).gameObject;
        laser.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        print("CU");
        if(other.gameObject.tag == "Quebrador"){
           Destroy(other.gameObject);
           //Instantiate (smoke, other.gameObject.transform.position, Quaternion.Euler(-90,0,0));
        }
    }

    void Update(){
        GrabTypes startingGrabType = hand.GetGrabStarting();
        if (startingGrabType == GrabTypes.Grip){
            laser.SetActive(true);
            laser.GetComponent<Animator>().SetBool("On",true);
        }
        else if (hand.GetGrabEnding(GrabTypes.Grip) == GrabTypes.Grip){
            laser.GetComponent<Animator>().SetBool("On",false);
            laser.SetActive(false);
        }
    }
}
