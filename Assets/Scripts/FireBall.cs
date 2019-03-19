using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour, IDestroyable
{
    private Monster monster;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            monster = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
        else
            IDestroy();

        if (monster == null)
            Debug.Log("Monster is null in FireBall script!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Fireball collision");
        if(other.gameObject.tag=="Player" && monster!=null)
        {
            other.gameObject.GetComponent<Monster>().Death();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            Destroy(this.gameObject);
        }
    }

    public void IDestroy()
    {
        Destroy(this.gameObject);
    }
}
