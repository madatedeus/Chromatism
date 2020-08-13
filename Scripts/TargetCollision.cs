using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    public int health;
    public GameObject boxToGenerate;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        // health = 3;
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Target was Hit!");
            Destroy(col.gameObject);
            source.Play();
            /*
            health -= 1;
            if (health == 0)
            {
                Debug.Log("Target destroyed. Creating new target...");
                Instantiate(boxToGenerate);
                Destroy(gameObject);
            }
            */
        }
    }
}
