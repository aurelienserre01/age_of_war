using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.EventArgs;

public class TowerHealth : MonoBehaviour
{
    
    public float health = 500f;

    public  event Action TowerDestroyed;
    // Start is called before the first frame update

    private void Start()
    {
        
    }

    public void StartGame()
    {
        health = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Tower Destroyed");
            TowerDestroyedHandler();
        }
    }
    
    private void TowerDestroyedHandler()
    { 
        TowerDestroyed?.Invoke();
    }
}
