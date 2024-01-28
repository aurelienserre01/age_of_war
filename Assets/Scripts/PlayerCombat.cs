using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Coroutine _attackCoroutine;
    public float attackRange = 20f;

    public GameObject attackPoint;
    public float delay = 0.5f;
    public float damage = 10f;

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

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        other.GetComponent<PlayerHealth>().health -= damage;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Warrior_enemy"))
        {
            StartCombat(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Warrior_enemy"))
        {
            StopCombat();
        }
    }
}
