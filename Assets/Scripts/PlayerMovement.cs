using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;



    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movement = new Vector2(1, 0).normalized;
        _rigidbody2D.velocity = _movement * speed;
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Warrior_enemy") || other.gameObject.CompareTag("Warrior_allies"))
        {
            _rigidbody2D.velocity = _movement * 0;
            Debug.Log("Colision");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Warrior_enemy") || other.gameObject.CompareTag("Warrior_allies"))
        {
            _rigidbody2D.velocity = _movement * speed;
            Debug.Log("Colision Exit");

        }
    }

}
