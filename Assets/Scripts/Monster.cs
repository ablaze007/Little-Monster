using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour, IDestroyable
{
    //Handlers
    private Rigidbody2D _rigid;
    private Animator _anim;

    public GameObject scoreScreen;
    public GameObject gameManager;
    public GameObject deadEye;

    public Text scoreText;
    public Text scoreScreenText;

    [SerializeField]
    private float jumpforce = 5.0f;
    [SerializeField]
    private float jumpResetTime = 0.1f;
    private bool isJumping = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = this.GetComponent<Rigidbody2D>();
        _anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
            scoreText.text = "Score - " + HighScore.GetScore();
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
        StartCoroutine(DeathRoutine());
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

    IEnumerator DeathRoutine()
    {
        deadEye.SetActive(true);
        scoreScreenText.text = "Score - " + HighScore.GetScore();
        scoreScreen.SetActive(true);
        HighScore.UpdateScore();
        yield return new WaitForSeconds(3.0f);
        gameManager.GetComponent<GameManager>().EndGame();
    }
}
