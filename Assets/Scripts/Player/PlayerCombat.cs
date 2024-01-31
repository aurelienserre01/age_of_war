using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Coroutine _attackCoroutine;
    private Coroutine _attackTowerCoroutine;
    private Player _playerData;
    public float attackRange = 20f;

    public GameObject attackPoint;
    public float delay = 0.5f;
    public float damage = 500f;

    public LayerMask enemyLayer;  
    // Start is called before the first frame update
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }
    
    public void StartCombat(Collider2D other)
    {
            _attackCoroutine = StartCoroutine(AttackCoroutine(other));
    }
    
    public void StartCombatTower(Collider2D other)
    {
        _attackTowerCoroutine = StartCoroutine(AttackTowerCoroutine(other));
    }
    
    public void stopCombatTower()
    {
        if (_attackTowerCoroutine == null) return;
        StopCoroutine(_attackTowerCoroutine);
        _attackTowerCoroutine = null;
    }
    
    private void StopCombat()
    {
        if (_attackCoroutine == null) return;
        StopCoroutine(_attackCoroutine);
        _attackCoroutine = null;
    }
    
    private IEnumerator AttackCoroutine(Collider2D other)
    {
        Attack(other);
        yield return new WaitForSeconds(delay);
        StartCombat(other);
    }
    
    private IEnumerator AttackTowerCoroutine(Collider2D other)
    {
        AttackTower(other);
        yield return new WaitForSeconds(delay);
        StartCombatTower(other);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack(Collider2D other)
    {
        other.GetComponent<PlayerHealth>().health -= damage;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void AttackTower(Collider2D other)
    {
        other.GetComponent<TowerHealth>().health -= damage;
        Debug.Log(other.GetComponent<TowerHealth>().health);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Warrior_enemy") || other.gameObject.CompareTag("Warrior_allies"))
        {
            if (!other.gameObject.CompareTag(gameObject.tag))
            {
                StartCombat(other);    
            }
                
        }

        if ((other.gameObject.CompareTag("Tower_allies") && gameObject.CompareTag("Warrior_enemy")) || (other.gameObject.CompareTag("Tower_enemy") && gameObject.CompareTag("Warrior_allies")))
        {
            StartCombatTower(other);    
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Warrior_enemy") || other.gameObject.CompareTag("Warrior_allies"))
        {
            StopCombat();
        }
        
        if(other.gameObject.CompareTag("Tower_allies") || other.gameObject.CompareTag("Tower_enemy"))
        {
            stopCombatTower();
        }
    }
}
