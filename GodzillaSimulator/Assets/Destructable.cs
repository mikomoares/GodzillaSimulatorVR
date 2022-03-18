using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public bool teste;
    public GameObject broken, explosion, smoke;
    // Update is called once per frame
    void Update()
    {
        if (teste){
            Instantiate(broken, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Quebrador"){
            teste = true;
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        }
    }
}