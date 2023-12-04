using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem damageEffect;
    //HealthBar hb;
    public void takeDamage(float amount){
        health-=amount;
        damageEffect.Play();
        if(health<=0){
            //StartCoroutine(Example());

            Die();
            health=50f;
        }
    }
   

    void Die(){
        //hb.EnemyKilled(1);
        gameObject.SetActive(false);
    }
}
