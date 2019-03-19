using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, IDestroyable
{
    public GameObject fireball;

    private bool isReady = false;
    [SerializeField]
    private float coolDownTime = 2.0f;
    [SerializeField]
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBallCoolDownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (fireball != null && isReady)
        {
            //fire!!
            isReady = false;
            Instantiate(fireball, GetPositionForFireBall(), Quaternion.identity);
            StartCoroutine(FireBallCoolDownRoutine());
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public Vector3 GetPositionForFireBall()
    {
        Vector3 position;
        if (this.transform.localScale.y>0)
            position = new Vector3(this.transform.position.x - 0.6f, this.transform.position.y + 0.285f, 0);
        else 
            position = new Vector3(this.transform.position.x - 0.6f, this.transform.position.y - 0.285f, 0);
        return position;
    }

    public void IDestroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator FireBallCoolDownRoutine()
    {
        yield return new WaitForSeconds(coolDownTime);
        isReady = true;
    }
}
