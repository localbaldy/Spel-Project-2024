using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SisterEnemyScript : MonoBehaviour
{
    public int health = 100;
    public float chaseRadius = 10f; // radie inom vilken fienden ska jaga spelaren
    public float obstacleCheckDistance = 1f; // avst�ndet som fienden ska kolla efter hinder framf�r sig
    public LayerMask obstacleLayerMask; // vilken lager fienden ska kolla efter hinder p�
    public Animator animator;
    private Transform target; // referens till spelaren
    private bool isChasing = false; // flagga f�r att indikera om fienden jagar eller inte
    public float moveSpeed = 5f;
    private Vector3 originalScale;
    private bool IsBlinking = false;
    public Animator Animator;
    public Animator Animator2;
    public Animator Animator3;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // s�ker efter spelaren i scenen baserat p� taggen
        originalScale = transform.localScale; // Spara den ursprungliga skalan
    }
    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius) // kollar om spelaren �r inom radie
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
        if (isChasing)
        {
            // kolla om det finns hinder framf�r fienden med OverlapBox
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 boxSize = new Vector2(1f, 1f); // storleken p� boxen som fienden ska kolla i
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, direction, obstacleCheckDistance,
            obstacleLayerMask);
            if (hit.collider == null)
            {
                // om det inte finns n�got hinder, r�r fienden mot spelarens position med hj�lp av MoveTowards()
                Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);
        if (health <= 0)
        {
            Die();
        }
        

    }

    
    void Die()
    {
        Destroy(gameObject);
        Animator.SetBool("Cycle2", true);
        Animator2.SetBool("Cycle2", true);
        Animator3.SetBool("Cycle2", true);
    }
}