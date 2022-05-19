using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] possibleObjs;
    public GameObject actualObj;
    void Start()
    {
        int randomNum = Random.Range(0,possibleObjs.Length);
        actualObj = GameObject.Instantiate(possibleObjs[randomNum], new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        actualObj.transform.parent = this.gameObject.transform; 
    }
}
