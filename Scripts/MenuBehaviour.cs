using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public AudioSource source;
    
    public void Start()
    {
        source = this.GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        source.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        source.Play();
        Application.Quit();
    }
}
