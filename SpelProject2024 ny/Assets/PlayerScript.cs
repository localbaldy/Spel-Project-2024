using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D m_Rigidbody2D;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        m_Rigidbody2D.velocity = new Vector2(5 * moveX, m_Rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	if(collision.tag == "NextLevel")
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	else if(collision.tag == "PreviousLevel")
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

