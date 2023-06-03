using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;
    private Rigidbody playerRb;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isOnGround = true;
    public bool gameOver = false;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }
    
    // Update is called once per frame
    void Update()
    {
        //スペースキーがおされて、かつ地面にいたら
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if(gameOver == false)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            if(gameOver == false)
            {
                explosionParticle.Play();
                gameOver = true;
            }
            dirtParticle.Stop();
        }
    }
}
