using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] possibleColors;

    void Start()
    {
        MeshRenderer my_renderer = this.GetComponent<MeshRenderer>();
        if ( my_renderer != null )
        {
            my_renderer.material = possibleColors[Random.Range(0,possibleColors.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
