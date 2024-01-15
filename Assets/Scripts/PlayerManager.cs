using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Player playerPrefab;
    public Transform spawner;
    public List<PlayerData> playerData;
    private List<Player> _players = new List<Player>();
    public Transform containerAlly;
    public Transform progressBar;

    public Player playerPrefabEnemy;
    public Transform containerEnemy;
    public Transform spawnerEnemy;
    
    private bool _spawning = false;
    private float value = 0f;

    IEnumerator WaitSeconds(int secondes)
    {
        _spawning = true;
        yield return new WaitForSeconds(secondes);
        _spawning = false;
    }

    private void Start()
    {
        StartCoroutine(startSwpanEnemies());
    }

    public void Update()
    {
        
        if (_spawning == false)
        {
            value = 0f;
            progressBar.localScale = new Vector2(0,0);
        }

        if (_spawning == true)
        {
            value += 0.03f;
            progressBar.localScale = new Vector2(value,1 );
        }
    }

    public void SpawnAllies(int number)
    {
        if (_spawning == false)
        {
            var data = playerData[number];
            var player = Instantiate(playerPrefab, spawner.position, Quaternion.identity, containerAlly);
            player.Data = data;
            _players.Add(player);
            StartCoroutine(WaitSeconds(2));
        }
       
    }

    private void startSwpanEnemies()
    {
        
    }

    private void RemovePlayer(Player player)
    {
        _players.Remove(player);
        Destroy(player.gameObject);
    }

    public void Reset()
    {
        for (var i = _players.Count - 1; i >= 0; i--)
        {
            RemovePlayer(_players[i]);
        }

        _players.Clear();
    }
    
}
