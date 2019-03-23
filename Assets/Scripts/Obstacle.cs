using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDestroyable
{
    protected float speed = 1.50f;
    [SerializeField]
    protected Vector2 force = new Vector2(100f,100f);

    protected Monster monster;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            monster = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();

        if (monster == null)
            Debug.Log("Monster is null in Obstacle script - "+this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void IDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && monster != null)
        {
            other.gameObject.GetComponent<Monster>().Death();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
}
