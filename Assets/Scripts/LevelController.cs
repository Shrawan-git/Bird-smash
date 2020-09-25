using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static int _nextLevelIndex = 1;
    public Enemy[] _enemies;

    public float timeLeft = 3.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 


    public void OnEnable(){
        _enemies = FindObjectsOfType<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)  //If enemies are not destroyed
            return;  
        }
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            // Load a new game scene/level
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
        }
        
    }
}
