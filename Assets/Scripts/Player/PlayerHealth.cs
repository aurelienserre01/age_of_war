using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Player _playerData;

    public float health;
    // Start is called before the first frame update
    private void Start()
    {
        
        _playerData = GetComponent<Player>();
        health = _playerData.Data.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
