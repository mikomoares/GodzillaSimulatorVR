using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHotspot : MonoBehaviour
{
    private GameObject gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            print(other.name);
            gameManager.GetComponent<GameManager>().AddPoint(this.gameObject.name);
        }
    }
}
