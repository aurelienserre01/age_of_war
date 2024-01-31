using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D texture;
    public float speed;
    public float damage;
    public float health;
    public int attackPerSec;
    public int score;
    public int cost;
    public bool ally;
    
    private PlayerData _data;
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    public PlayerData Data
    {
        get => _data;
        set
        {
            
            _data = value;
            texture = _data.texture;
            _playerMovement.speed = _data.speed;
            _spriteRenderer.sprite = Sprite.Create(_data.texture, new Rect(0.0f, 0.0f, _data.texture.width, _data.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            damage = _data.damage;
            health = _data.health;
            attackPerSec = _data.attackPerSec;
            score = _data.score;
            cost = _data.cost;
            ally = _data.ally;
            
        }
    }
}
