using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationTransition : MonoBehaviour
{
    [SerializeField] private AudioSource Panga;
    // Start is called before the first frame update
    public void StartGame()
{
	SceneManager.LoadScene(11);
}

 public void Pang()
    {
        Panga.Play();
    }

public void StartGame1()
{
	SceneManager.LoadScene(6);
}

}
