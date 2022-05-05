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

    public Vector3 interactionRayPoint = new Vector3 (0.5f,0.5f,0f);

    void Start()
    {
        camera3rd = this.gameObject.transform.GetChild(0).gameObject;
        activeForm = possibleForms[Random.Range(0,possibleForms.Length)];
        childForm = GameObject.Instantiate(activeForm, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        childForm.transform.parent = this.gameObject.transform; 
    }

    void Update()
    {


        if(childForm != null){
            this.transform.position = childForm.transform.position;
        }

        if(Physics.Raycast(camera3rd.GetComponent<Camera>().ViewportPointToRay(interactionRayPoint) , out RaycastHit hit, 500f, layerInteraction)){
            print("hit");
        }

        if(Input.GetKeyUp(KeyCode.F)){
            InstantiateNewForm();
        }
    }

    private void InstantiateNewForm(){
        Destroy(childForm);
        activeForm = possibleForms[Random.Range(0,possibleForms.Length)];
        childForm = GameObject.Instantiate(activeForm, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        childForm.transform.parent = this.gameObject.transform; 
    }
}
