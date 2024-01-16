using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    public Animator animator; // Ref till vår animator
    public Rigidbody2D rb; // Ref till vår rigidbody
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Om vi kolliderar med trap, starta die funktionen
        {
            Die();
            Debug.Log("touch");
        }
    }
    private void Die() // Spela death animationen och sätt rigidbody på static så vi inte kan röra oss
    {
        //animator.SetTrigger("Death");
        //rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("dead");
    }
    private void RestartLevel() // Starta om scenen när vi dör
    {
        SceneManager.LoadScene(0);
    }
}