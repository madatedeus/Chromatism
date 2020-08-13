using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehaviour : MonoBehaviour
{
    public AudioSource source;

    public void Start()
    {
        source = this.GetComponent<AudioSource>();
    }
    public void ReplayGame()
    {
        source.Play();
        // - 3 returns to the main menu
        // if player lost, they go back to tutorial instead to try again
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void Quit()
    {
        source.Play();
        Application.Quit();
    }
}
