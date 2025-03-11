using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // public variables
    int playerLives = 5;
    int enemyWaves = 5;
    bool playerAlive = true

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // loss condition
    public void lose()
    {
        if (playerLives <= 0)
        {
            Application.Quit();
        }
    }

    public void win()
    {

    }
}