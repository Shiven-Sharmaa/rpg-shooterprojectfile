using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene : MonoBehaviour
{
    public void tryagain(){
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }
    public void exit(){
        Application.Quit();
    }
}
