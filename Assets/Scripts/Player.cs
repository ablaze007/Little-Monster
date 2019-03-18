using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Handlers
    private Rigidbody2D _rigid;

    [SerializeField]
    private float jumpforce = 2.0f;
    [SerializeField]
    private float jumpResetTime = 0.25f;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void jump()
    {
        if (isJumping)
            return;
        isJumping = true;
        _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
        StartCoroutine(JumpResetRoutine());
    }

    IEnumerator JumpResetRoutine()
    {
        yield return new WaitForSeconds(jumpResetTime);
        isJumping = false;
    }

}
