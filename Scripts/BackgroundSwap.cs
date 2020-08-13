using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwap : MonoBehaviour
{
    // Levels
    public GameObject bulletBill, doodleBob, sans;

    // Background colors
    public float r, g, b, a;
    public Color pinkColor, greenColor, yellowColor;

    public AudioSource source;

    // Walls
    public GameObject white, pink, green, yellow;

    // Start is called before the first frame update
    void Start()
    {
        // Determine the levels
        bulletBill = GameObject.Find("bulletBill");
        doodleBob = GameObject.Find("doodleBob");
        sans = GameObject.Find("sans");

        // begin the game with a white background
        Camera.main.backgroundColor = Color.white;

        source = this.GetComponent<AudioSource>();

        a = 1; // color alpha always highest

        // pink background
        r = 1;
        g = 0.494f;
        b = 0.8667f;
        pinkColor = new Color(r, g, b, a);

        // green background
        r = 0.145098f;
        g = 0.905980f;
        b = 0.403921f;
        greenColor = new Color(r, g, b, a);

        // yellow background
        r = 1;
        g = 0.90589f;
        b = 0.27843f;
        yellowColor = new Color(r, g, b, a);

        // finding the walls
        white = GameObject.FindGameObjectWithTag("White");
        pink = GameObject.FindGameObjectWithTag("Pink");
        green = GameObject.FindGameObjectWithTag("Green");
        yellow = GameObject.FindGameObjectWithTag("Yellow");
    }

    // Update is called once per frame
    void Update()
    {
        // Press SpaceBar to switch background colors
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.Play();

            /***************************** LEVEL SYSTEM ************************/
            // Whenever the Spacebar is hit, if the color of the background is a certain color
            // it will swap to another color, disable collision on the color the background was changed to
            // and enable collision on all other colors.
            // Each level will increase a number of colors, therefore each level must be accounted for.

            // Level 1
            if (bulletBill != null)
            {
                if (Camera.main.backgroundColor == Color.white)
                {
                    Camera.main.backgroundColor = pinkColor;
                    pink.GetComponent<Collider2D>().enabled = false;

                    white.GetComponent<Collider2D>().enabled = true;
                }

                else
                {
                    Camera.main.backgroundColor = Color.white;
                    white.GetComponent<Collider2D>().enabled = false;

                    pink.GetComponent<Collider2D>().enabled = true;
                }

            }

            // Level 2, more colors
            else if (doodleBob != null)
            {
                if (Camera.main.backgroundColor == Color.white)
                {
                    Camera.main.backgroundColor = pinkColor;
                    pink.GetComponent<Collider2D>().enabled = false;

                    white.GetComponent<Collider2D>().enabled = true;
                    green.GetComponent<Collider2D>().enabled = true;
                }
                else if (Camera.main.backgroundColor == pinkColor)
                {
                    Camera.main.backgroundColor = greenColor;
                    green.GetComponent<Collider2D>().enabled = false;

                    white.GetComponent<Collider2D>().enabled = true;
                    pink.GetComponent<Collider2D>().enabled = true;
                }
                else
                {
                    Camera.main.backgroundColor = Color.white;
                    white.GetComponent<Collider2D>().enabled = false;

                    green.GetComponent<Collider2D>().enabled = true;
                    pink.GetComponent<Collider2D>().enabled = true;
                }
            }

            // Level 3
            else if (sans != null)
            {
                if (Camera.main.backgroundColor == Color.white)
                {
                    Camera.main.backgroundColor = pinkColor;
                    pink.GetComponent<Collider2D>().enabled = false;

                    white.GetComponent<Collider2D>().enabled = true;
                    green.GetComponent<Collider2D>().enabled = true;
                    yellow.GetComponent<Collider2D>().enabled = true;
                }
                else if (Camera.main.backgroundColor == pinkColor)
                {
                    Camera.main.backgroundColor = greenColor;
                    green.GetComponent<Collider2D>().enabled = false;

                    white.GetComponent<Collider2D>().enabled = true;
                    pink.GetComponent<Collider2D>().enabled = true;
                    yellow.GetComponent<Collider2D>().enabled = true;
                }
                else if (Camera.main.backgroundColor == greenColor)
                {
                    Camera.main.backgroundColor = yellowColor;
                    yellow.GetComponent<Collider2D>().enabled = false;

                    white.GetComponent<Collider2D>().enabled = true;
                    green.GetComponent<Collider2D>().enabled = true;
                    pink.GetComponent<Collider2D>().enabled = true;
                }
                else
                {
                    Camera.main.backgroundColor = Color.white;
                    white.GetComponent<Collider2D>().enabled = false;

                    green.GetComponent<Collider2D>().enabled = true;
                    pink.GetComponent<Collider2D>().enabled = true;
                    yellow.GetComponent<Collider2D>().enabled = true;
                }
            }

        }
    }

}
