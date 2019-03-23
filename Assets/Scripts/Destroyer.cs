using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Destroyer Triggered!");
        IDestroyable other = collision.GetComponent<IDestroyable>();

        if(other!=null && collision.tag != "Player")
        {
            other.IDestroy();
            if(monster!=null && !monster.GetComponent<Monster>().isDead)
                HighScore.AddScore();
        }
    }
}
