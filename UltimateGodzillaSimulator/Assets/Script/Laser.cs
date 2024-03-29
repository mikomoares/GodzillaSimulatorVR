using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Hand handLeft;
    public Hand handRight;
    private GameObject laser;
    private AudioSource audioS;
    public float startTimerA;
    public float timerA;
    public float startTimerB;
    public float timerB;
    public bool canDoLaser;
    public GameObject textCooldown;

    void Start(){
        laser = transform.GetChild(0).gameObject;
        laser.SetActive(false);
        audioS = this.GetComponent<AudioSource>();
        startTimerA = 14f;
        timerA = startTimerA;
        startTimerB = 4f;
        timerB = startTimerB;
        canDoLaser = true;
        textCooldown.SetActive(false);
    }

    async void Update(){

        GrabTypes startingGrabTypeRight = handRight.GetGrabStarting();
        GrabTypes startingGrabTypeLeft = handLeft.GetGrabStarting();
        timerB -= Time.deltaTime;
        textCooldown.GetComponent<Text>().text = Mathf.Round(timerA).ToString();

        if(!canDoLaser){
            timerA -= Time.deltaTime;
            if(timerA <= 0){
                canDoLaser = true;
                textCooldown.SetActive(false);
            }
        }

        if ((startingGrabTypeRight == GrabTypes.Grip || startingGrabTypeLeft == GrabTypes.Grip) && canDoLaser){
            laser.SetActive(true);
            laser.GetComponent<Animator>().SetBool("On",true);
            audioS.Play();
            timerB = startTimerB;
            timerA = startTimerA;
            canDoLaser = false;
        }
        
        if (timerB <= 0 && !canDoLaser){
            laser.GetComponent<Animator>().SetBool("On",false);
            audioS.Pause();
            laser.SetActive(false);
            timerB = 4f;
            textCooldown.SetActive(true);
        }
    }
}
