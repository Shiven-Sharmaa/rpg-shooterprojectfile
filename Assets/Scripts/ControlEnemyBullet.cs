using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemyBullet : MonoBehaviour
{
    Transform player;
    public float dist;
    public float triggerDistance;
    public Transform enemy;
    public GameObject bullet;
    public float shootPower=1000f;
    public float fireRate;
    public float nextFire;
    // Start is called before the first frame update
    void Start()
    {
            player=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position,transform.position);
        if(dist<=triggerDistance){
            enemy.LookAt(player);
            transform.LookAt(player);
            if(Time.time>=nextFire){
                nextFire=Time.time+1f/fireRate;
            shoot();
            }
        }
    }

    void shoot(){
        GameObject bulletClone = Instantiate(bullet,transform.position,transform.rotation);
        bulletClone.GetComponent<Rigidbody>().AddForce(enemy.forward*shootPower);
        Destroy(bulletClone,5);
    }   
}
