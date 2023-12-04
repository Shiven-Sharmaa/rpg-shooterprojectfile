using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour
{
    public float lives  = 3f;
    public float health=100f;
    public Text enemiesLeft;
    public Transform player;

    public List<GameObject> enemies;
    public List<Image> hearts;
    public float enemyCount=0;
    public GameObject damageIndicator; 
    public float damageDuration = 0.5f; 

    void start(){
        HealthBarHandler.SetHealthBarValue(1);
        damageIndicator.SetActive(false);
    }


    void Update(){
        enemyCount=0;
        for(int i=0;i<enemies.Count;i++){
           if(enemies[i].activeSelf){
            enemyCount+=1;
           }
        }
        if(enemyCount==0){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(4);
        }
        enemiesLeft.text=enemyCount.ToString();
        if(lives<=0){
            //load end screen
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(3);
        }
        if (health<=10){
            RestartSet();
            lives-=1;
            Debug.Log("Player died");
            hearts[(int)lives].enabled=false;
            
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy")
            health-=10;
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.1f);
            ShowDamageIndicator();
            CancelInvoke("HideDamageIndicator"); 
            Invoke("HideDamageIndicator", damageDuration);
    }
    public void ShowDamageIndicator()
    {
        Debug.Log("showing damage");
        damageIndicator.SetActive(true);
    }
 
    public void HideDamageIndicator()
    {
        Debug.Log("Hiding damage");
        damageIndicator.SetActive(false);
    }
    void RestartSet(){
        player.position = new Vector3(22,4,-7);
        health=100f;
        HealthBarHandler.SetHealthBarValue(1f);
        //for(int i=0;i<enemies.Count;i++){
          // enemies[i].SetActive(true);
        //}
    }
}
