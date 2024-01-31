using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Player playerPrefab;
    public Transform spawner;
    public List<PlayerData> playerData;
    private List<Player> _players = new List<Player>();
    public Transform containerAlly;

    public Image bar;

    public Player playerPrefabEnemy;
    public Transform containerEnemy;
    public Transform spawnerEnemy;
    
    private bool _spawning = false;
    private float _value = 0.5f;

    IEnumerator WaitSeconds(int secondes)
    {
        _spawning = true;
        yield return new WaitForSeconds(secondes);
        _spawning = false;
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
    
    
    public void StartGame()
    {
        StartCoroutine(startSwpanEnemies());
    }

    public void Update()
    {
        
        if (_spawning == false)
        {
            bar.fillAmount = 0;
        }

        if (_spawning)
        {
            
            bar.fillAmount += Mathf.Clamp01(Time.deltaTime);
            Debug.Log(bar.fillAmount);
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

    private IEnumerator startSwpanEnemies()
    {
        yield return new WaitForSeconds(3f);
        var data = playerData[5];
        var numberRandom = UnityEngine.Random.Range(0, 100);
        if (numberRandom < 25)
        {
            data = playerData[3];
        }

        if ( numberRandom >= 26 && numberRandom < 50)
        {
            data = playerData[4];
        }
        var newEnemy = Instantiate(playerPrefabEnemy, spawnerEnemy.position, Quaternion.identity, containerEnemy);
        newEnemy.Data = data;
        StartCoroutine(startSwpanEnemies());
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
