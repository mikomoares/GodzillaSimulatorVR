using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuildingSpawner : MonoBehaviour
{
    public GameObject[] possibleBuildings;
    public GameObject actualBuilding;
    void Start()
    {
        int randomNum = Random.Range(0,possibleBuildings.Length);
        actualBuilding = GameObject.Instantiate(possibleBuildings[randomNum], new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        actualBuilding.transform.parent = this.gameObject.transform; 
    }
}
