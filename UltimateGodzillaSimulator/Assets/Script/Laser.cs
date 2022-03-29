using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Hand hand;
    private GameObject laser;

    void Start(){
        laser = transform.GetChild(0).gameObject;
        laser.SetActive(false);
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
