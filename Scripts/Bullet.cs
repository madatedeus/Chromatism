using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // bullet trajectory
    public float bulletSpeed;
    public Rigidbody2D rb;

    // wall objects
    public GameObject innerGreen, greenWall, innerYellow, yellowWall;

    // Enemies
    public GameObject[] enemies;

    // Endgame
    public GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 1.0f;
        rb = this.GetComponent<Rigidbody2D>();

        innerGreen = GameObject.FindGameObjectWithTag("InnerGreen");
        innerYellow = GameObject.FindGameObjectWithTag("InnerYellow");

        // setting the enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // endgame
        endText = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // If the bullet hits any walls, destroy it
        if (col.gameObject.tag == "Outer" || col.gameObject.tag == "White" ||
            col.gameObject.tag == "Green" || col.gameObject.tag == "Pink" ||
            col.gameObject.tag == "Yellow")
        {
            Debug.Log("Bullet out of bounds.");
            Destroy(gameObject);
        }

        // If the 
        if (col.gameObject.tag == "Enemy")
        {
            if (enemies.Length == 3)
            {
                Destroy(innerGreen);
            }

            if (enemies.Length == 2)
            {
                Destroy(innerYellow);
            }

            if (enemies.Length == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
    
            Destroy(gameObject);
            Destroy(col.gameObject);

        }
    }
}
