using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballEmitter_Hard : MonoBehaviour
{
    public GameObject fireBall;
    public float randomNum;
    public float randomPos;

    public GameObject bulletBill, doodleBob, sans;

    public AudioSource source;

    void Start()
    {
        bulletBill = GameObject.Find("bulletBill");
        doodleBob = GameObject.Find("doodleBob");
        sans = GameObject.Find("sans");
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletBill != null)
            return;
        else if (doodleBob != null)
            return;
        else
        {
            if (sans != null)
            {
                randomNum = Random.Range(0.0f, 1.0f);
                randomPos = Random.Range(-4.0f, 2.0f);

                if (randomNum < 0.025)
                {
                    source.Play();
                    // instantiate a new fireball
                    Instantiate(fireBall,
                        new Vector3(gameObject.transform.position.x + randomPos,
                                    gameObject.transform.position.y,
                                    0),
                        new Quaternion(0, 0, 0, 0));
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    }
}
