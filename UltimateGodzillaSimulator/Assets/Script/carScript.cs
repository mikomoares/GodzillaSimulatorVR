using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript : MonoBehaviour
{
    public bool isAlive;
    void Start()
    {
        isAlive = true;
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Quebrador" || other.gameObject.tag == "Hand" ){
            isAlive = false;
        }
    }
}
