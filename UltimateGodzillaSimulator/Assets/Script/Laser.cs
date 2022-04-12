using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Hand handLeft;
    public Hand handRight;
    private GameObject laser;
    private AudioSource audioS;

    void Start(){
        laser = transform.GetChild(0).gameObject;
        laser.SetActive(false);
        audioS = this.GetComponent<AudioSource>();
    }

    void Update(){
        GrabTypes startingGrabTypeRight = handRight.GetGrabStarting();
        GrabTypes startingGrabTypeLeft = handLeft.GetGrabStarting();
        if (startingGrabTypeRight == GrabTypes.Grip || startingGrabTypeLeft == GrabTypes.Grip){
            laser.SetActive(true);
            laser.GetComponent<Animator>().SetBool("On",true);
            audioS.Play();
        }
        else if (handRight.GetGrabEnding(GrabTypes.Grip) == GrabTypes.Grip || handLeft.GetGrabEnding(GrabTypes.Grip) == GrabTypes.Grip){
            laser.GetComponent<Animator>().SetBool("On",false);
            audioS.Pause();
            laser.SetActive(false);
        }
    }
}
