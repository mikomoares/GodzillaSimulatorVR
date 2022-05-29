using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject player, hotspots, activeHS, timers;
    public float time;
    public int points, randomChildIdx;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ComputerPlayer");
        hotspots = GameObject.Find("Hotspots");
        timers = GameObject.Find("Timers");
        
        time = 300f;
        foreach (Transform child in hotspots.transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        randomChildIdx = Random.Range(0, hotspots.transform.childCount);
        activeHS = hotspots.transform.GetChild(randomChildIdx).gameObject;
        activeHS.GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        foreach (Transform child in timers.transform)
        {
            child.GetChild(1).gameObject.GetComponent<Text>().text = time.ToString();
        }

        if (time <= 0){
            GameOver();
        }
        if (points >= 5){
            Victory();
        }
    }

    private void GameOver(){
        print("Godzilla ganhou");
    }

    private void Victory(){
        print ("Player ganhou");
    }

    public void AddPoint(string name){
        if (name == activeHS.name){
            points ++;
            activeHS.GetComponent<BoxCollider>().enabled = false;
            randomChildIdx = Random.Range(0, hotspots.transform.childCount);
            activeHS = hotspots.transform.GetChild(randomChildIdx).gameObject;
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
