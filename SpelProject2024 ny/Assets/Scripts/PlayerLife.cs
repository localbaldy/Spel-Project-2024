using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    public Animator animator; // Ref till v�r animator
    public Rigidbody2D rb; // Ref till v�r rigidbody
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Om vi kolliderar med trap, starta die funktionen
        {
            Die();
            Debug.Log("touch");
        }
    }
    private void Die() // Spela death animationen och s�tt rigidbody p� static s� vi inte kan r�ra oss
    {
        //animator.SetTrigger("Death");
        //rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("dead");
    }
    private void RestartLevel() // Starta om scenen n�r vi d�r
    {
        SceneManager.LoadScene(0);
    }
}