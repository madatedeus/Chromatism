using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fireball_Medium : MonoBehaviour
{
    // bullet trajectory
    public float fireballSpeed;
    public Rigidbody2D rb;

    // wall objects
    public GameObject innerGreen, greenWall, innerYellow, yellowWall;
    public GameObject whiteWall, pinkWall;
    // Enemies
    public GameObject[] enemies;

    // Endgame
    public GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        fireballSpeed = 5.0f;
        rb = this.GetComponent<Rigidbody2D>();

        // start walls
        innerGreen = GameObject.FindGameObjectWithTag("InnerGreen");
        greenWall = GameObject.FindGameObjectWithTag("Green");
        innerYellow = GameObject.FindGameObjectWithTag("InnerYellow");
        yellowWall = GameObject.FindGameObjectWithTag("Yellow");
        whiteWall = GameObject.FindGameObjectWithTag("White");
        pinkWall = GameObject.FindGameObjectWithTag("Pink");

        // disabling colliders
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), whiteWall.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), greenWall.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), pinkWall.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), yellowWall.GetComponent<Collider2D>()); ;

        // setting the enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(new Vector2(0, -fireballSpeed), ForceMode2D.Impulse);
        rb.velocity = new Vector2(0, fireballSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Outer")
        {
            Debug.Log("Bullet out of bounds.");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
