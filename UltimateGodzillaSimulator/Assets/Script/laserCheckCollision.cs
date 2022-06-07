using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCheckCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smoke, GM;
    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Quebrador"){
           Destroy(other.gameObject);
           Instantiate (smoke, other.gameObject.transform.position, Quaternion.Euler(-90,0,0));
        }
        if(other.gameObject.tag == "Player"){
           GM.GetComponent<GameManager>().GameOver();
        }
    }
}
