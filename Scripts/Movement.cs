using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement
    public float speed, boost;
    public Rigidbody2D rb;
    Vector2 movement = new Vector2();

    // Audio
    private AudioSource source;

    // Actions
    public GameObject bullet;
    public GameObject lantern;
    public float pX, pY;

    // Start is called before the first frame update
    void Start()
    {
        // setting the character
        rb = this.GetComponent<Rigidbody2D>();
        source = this.GetComponent<AudioSource>();
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        speed = 5.0f;
        boost = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        rb.velocity = movement * speed;

        // Click left-button to shoot
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            source.Play();

            // Instantiate the fireball object
            pX = gameObject.transform.position.x;
            pY = gameObject.transform.position.y;
            Instantiate(bullet, new Vector3(pX + 1.5f, pY, 0), new Quaternion(0, 0, 0, 0));
        }

        // player goes faster if they hold down left shift
        if (Input.GetKey(KeyCode.LeftShift))
            speed = boost;
        else
            speed = 5.0f;

    }

}
