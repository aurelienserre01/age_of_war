using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public PlayerManager PlayerManager { get; private set; }

    private void awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this )
        {
            Destroy(gameObject);
        }
        PlayerManager = GetComponent<PlayerManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void StopGame()
    {
        PlayerManager.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
