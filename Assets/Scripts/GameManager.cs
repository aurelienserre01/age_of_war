using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerManager PlayerManager { get; private set; }
    public UIManager UIManager { get; private set; }
    
    public TowerHealth TowerHealth { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this )
        {
            Destroy(gameObject);
        }
        PlayerManager = GetComponent<PlayerManager>();
        UIManager = GetComponent<UIManager>();
        TowerHealth = GetComponent<TowerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        TowerHealth.TowerDestroyed += TowerDestroyedHandler;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void TowerDestroyedHandler()
    {
        StopGame();
    }
    
    private void StopGame()
    {
        Debug.Log("Game Over");
        PlayerManager.Reset();
        UIManager.StopGame();
    }
    
    public void StartGame()
    {
        PlayerManager.StartGame();
        UIManager.StartGame();
        TowerHealth.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
