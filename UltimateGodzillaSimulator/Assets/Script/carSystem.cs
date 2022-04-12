using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSystem : MonoBehaviour
{
    private GameObject car;
    private GameObject pointA;
    private GameObject pointB;
    public string targetPoint;
    private float step;
    public float speed;
    private Vector3 startRotation;
    private Vector3 turnRotation;
    private Vector3 alturaY;
    void Start()
    {
        car = this.gameObject.transform.GetChild(0).gameObject;
        pointA = this.gameObject.transform.GetChild(1).gameObject;
        pointB = this.gameObject.transform.GetChild(2).gameObject;
        car.transform.position = pointA.transform.position;
        targetPoint = "B";
        speed = 3f;
        startRotation = car.transform.eulerAngles;
        turnRotation = new Vector3 (startRotation.x, startRotation.y + 180, startRotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        step =  speed * Time.deltaTime; // calculate distance to move
        if(car != null){
            if(car.GetComponent<carScript>().isAlive){
                car.GetComponent<Collider>().attachedRigidbody.useGravity = false;
                if(targetPoint == "B"){
                    car.transform.eulerAngles = startRotation;
                    car.transform.position = Vector3.MoveTowards(car.transform.position, pointB.transform.position, step);
                    if (Vector3.Distance(car.transform.position, pointB.transform.position) < 0.001f)
                    {
                        targetPoint = "A";
                    }
                    alturaY = new Vector3 (car.transform.position.x,0.5f,car.transform.position.z);
                    car.transform.position = alturaY;
                }
                else if (targetPoint == "A"){
                    car.transform.eulerAngles = turnRotation;
                    car.transform.position = Vector3.MoveTowards(car.transform.position, pointA.transform.position, step);
                    if (Vector3.Distance(car.transform.position, pointA.transform.position) < 0.001f)
                    {
                        targetPoint = "B";
                    }
                    alturaY = new Vector3 (car.transform.position.x,0.5f,car.transform.position.z);
                    car.transform.position = alturaY;
                }
            }
            else{
                speed = 0f;
                car.GetComponent<Collider>().attachedRigidbody.useGravity = true;
            }
        }
        
    }
}
