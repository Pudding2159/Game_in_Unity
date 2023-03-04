using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Rey : MonoBehaviour
{
 
    public Transform offcet;
    public int grabPower = 1;
    public float distanse;
    public float distanseY;
    bool tumbler = false;
    Collider m_Collider;

    void Update()
    {

        //offcet.transform.position = transform.position;
        //offcet.transform.rotation = transform.rotation;
        //offcet.transform.position = new Vector3(transform.position.x,transform.position.y - distanseY,transform.position.z + distanse); 

        Ray ray = new Ray(transform.position,transform.forward);
        //ray.origin = transform.position;
        //ray.direction = transform.forward;
        Debug.DrawRay(transform.position,transform.forward*100f,Color.red);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.rigidbody != null)
            {
                //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    tumbler = !tumbler;
                    //hit.rigidbody.velocity = ((transform.position - (hit.transform.position + hit.rigidbody.centerOfMass))* grabPower);
                    //hit.collider.gameObject.GetComponent<Transform>().position = new Vector3(0,0,0);
                }                  
                if(tumbler == true)
                {    
                    //hit.rigidbody.velocity = ((offcet.position - (hit.transform.position + hit.rigidbody.centerOfMass))* grabPower);
                    hit.rigidbody.position = new Vector3(offcet.transform.position.x,offcet.transform.position.y,offcet.transform.position.z);
                    if( hit.rigidbody.useGravity != false)
                        hit.rigidbody.useGravity = false;
                    //hit.collider.enabled = false;
                }
                else
                    if( hit.rigidbody.useGravity != true)
                        hit.rigidbody.useGravity = true;    
            }
        }
    }
}
