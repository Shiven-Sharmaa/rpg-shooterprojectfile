using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage=10f;
    public float range = 10000f;

    public Camera fpsCam; 
    public GameObject laser;
    private float counter = 0f;
    public float target = 2f;
    private bool flag=false;

    


    void Shoot(){
        
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)){
            Debug.Log(hit.transform);
            Target target = hit.transform.GetComponent<Target>();
            if(target!=null){
                target.takeDamage(damage);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(flag && counter<target){
            counter += Time.deltaTime;
        }
        else{
            laser.SetActive(false);
            flag=false;
            counter=0f;
        }
        if(Input.GetButtonDown("Fire1")){
            Shoot();
            if(counter<target){
                laser.SetActive(true);
                flag=true;
            
            }
        }
    }
}
