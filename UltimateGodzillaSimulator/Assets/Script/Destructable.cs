using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public bool explosionBool;
    public GameObject broken, explosion, smoke;
    // Update is called once per frame
    void Update()
    {
        if (explosionBool){
            GameObject brokenBuilding = Instantiate(broken, transform.position, transform.rotation);
            foreach(Transform child in brokenBuilding.transform)
            {
                child.gameObject.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Quebrador"){
            explosionBool = true;
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        }
        else if(other.gameObject.tag == "Hand" ){
            if(other.gameObject.name == "laserComponent"){
                explosionBool = true;
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                Instantiate(smoke, this.transform.position, Quaternion.identity);
            }
            else{
                explosionBool = true;
                Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
                Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
