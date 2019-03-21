using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDestroyable
{
    //Handlers
    private Rigidbody2D _rigid;
    private Animator _anim;

    [SerializeField]
    private float jumpforce = 5.0f;
    [SerializeField]
    private float jumpResetTime = 0.1f;
    private bool isJumping = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = this.GetComponent<Rigidbody2D>();
        _anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void Jump()
    {
        if (isJumping || isDead)
            return;

        //Debug.Log("Jumping " + Time.deltaTime);
        isJumping = true;
        _anim.SetTrigger("Jump");
        _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
        StartCoroutine(JumpResetRoutine());
    }

    public void Death()
    {
        Debug.Log("Monster is Dead!");
        isDead = true;
    }

    public void IDestroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator JumpResetRoutine()
    {
        yield return new WaitForSeconds(jumpResetTime);
        isJumping = false;
    }
}
