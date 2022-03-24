using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smoke;

    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Quebrador"){
           Destroy(other.gameObject);
           //Instantiate (smoke, other.gameObject.transform.position, Quaternion.Euler(-90,0,0));
        }
    }
}
