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

        Debug.DrawRay(ray.origin, ray.direction * 20000f,  Color.red);

        if(Input.GetKeyUp(KeyCode.Mouse0)){
            if(Physics.Raycast(ray , out RaycastHit hit, 500f, layerInteraction)){
                InstantiateNewForm(hit);
            }
        }

        
    }

    private void InstantiateNewForm(RaycastHit hit){
        Destroy(childForm);
        foreach(GameObject go in possibleForms)
        {
            if(go.name == hit.transform.gameObject.name)
            {
                activeForm = go;
            }
        }
        Vector3 objPos = hit.transform.position;
        childForm = GameObject.Instantiate(activeForm, new Vector3 (this.transform.position.x, objPos.y, this.transform.position.z), Quaternion.identity);
        //childForm.transform.parent = this.gameObject.transform; 
    }
}
