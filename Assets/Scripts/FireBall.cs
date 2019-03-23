using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Obstacle
{
    [SerializeField]
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            monster = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
        else
            IDestroy();

        if (monster == null)
            Debug.Log("Monster is null in FireBall script!");

        speed = _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Fireball collision");
        if (other.gameObject.tag == "Player" && monster != null)
        {
            other.gameObject.GetComponent<Monster>().Death();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
        Destroy(this.gameObject);
    }
}
