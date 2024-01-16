using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public int health = 100;
    public float chaseRadius = 10f; // radie inom vilken fienden ska jaga spelaren
    public float obstacleCheckDistance = 1f; // avst�ndet som fienden ska kolla efter hinder framf�r sig
    public LayerMask obstacleLayerMask; // vilken lager fienden ska kolla efter hinder p�
    public Animator animator;
    private Transform target; // referens till spelaren
    private bool isChasing = false; // flagga f�r att indikera om fienden jagar eller inte
    public float moveSpeed = 5f;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // s�ker efter spelaren i scenen baserat p� taggen
        
         
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
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        
    }
}