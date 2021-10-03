using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    
    //basic script for changing and moving between scenes
    //as well as the toggling on and off of ui
    
    
    public int scenelevel;
    public void Scenechanger(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToggleObjectOff(GameObject target)
    {

        //set inactive
        target.SetActive(false);

    }

    public void ToggleObjectOn(GameObject target)
    {
        //set active
        target.SetActive(true);
    }
}
