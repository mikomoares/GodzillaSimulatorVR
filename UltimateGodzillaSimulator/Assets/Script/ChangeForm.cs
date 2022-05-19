using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    public GameObject[] possibleForms;

    public GameObject activeForm;

    private GameObject childForm;

    private GameObject camera3rd;

    public LayerMask layerInteraction;

    void Start()
    {
        camera3rd = GameObject.Find("Camera3rd");
        activeForm = possibleForms[Random.Range(0,possibleForms.Length)];
        childForm = GameObject.Instantiate(activeForm, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        //childForm.transform.parent = this.gameObject.transform; 
    }

    void Update()
    {


        if(childForm != null){
            this.transform.position = childForm.transform.position;
        }

        Ray ray = camera3rd.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        //Debug.DrawRay(ray.origin, ray.direction * 20000f,  Color.red);

        if(Input.GetKeyUp(KeyCode.Mouse0)){
            if(Physics.Raycast(ray , out RaycastHit hit, 500f, layerInteraction)){
                InstantiateNewForm(hit);
            }
        }

        
    }

    private async void InstantiateNewForm(RaycastHit hit){
        Destroy(childForm);

        for(int i = 0; i < possibleForms.Length; i++)
        {
            if(i == hit.transform.gameObject.GetComponent<InteractableObjects>().objID)
            {
                activeForm = possibleForms[i];
            }
        }

        Vector3 objPos = hit.transform.position;
        childForm = GameObject.Instantiate(activeForm, new Vector3 (this.transform.position.x, objPos.y, this.transform.position.z), Quaternion.identity);
        //childForm.transform.parent = this.gameObject.transform; 
    }
}
