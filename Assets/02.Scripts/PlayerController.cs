using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip itemClip;
    public float jumpForce = 300f;
    public GameObject petObject;

    private bool isDead = false;
    private bool isFever = false;
    private int playerLife = 2;

    private Rigidbody2D playerRb;
    private Animator animator;
    private AudioSource playerAudio;
    private Rigidbody2D petRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
        // 메뉴패널 켜져있으면 점프 안되게
        if (!GameManager.instance.menuPanel.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerRb.velocity = Vector2.zero;
                playerRb.AddForce(new Vector2(0, jumpForce));
                playerAudio.clip = jumpClip;
                playerAudio.Play();
            }

            else if (Input.GetMouseButtonUp(0) && playerRb.velocity.y > 0)
            {
                playerRb.velocity = playerRb.velocity * 0.5f;
            }
        }
        
        int currentScore = GameManager.instance.GetScore();

        if (currentScore >= 10)
        {
            petObject.SetActive(true);
            FeverTime();
        }

        if(currentScore >= 30)
        {
            isFever = false;
            animator.SetBool("Fever", isFever);
            petObject.SetActive(false);
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRb.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead)
        {
            if(other.tag == "Dead")
            {
                Die();
            }
            if(other.tag == "Fish")
            {
                playerAudio.PlayOneShot(deathClip);
                if (playerLife == 0)
                {
                    Die();
                }
                GameManager.instance.MinusLife(playerLife);
                playerLife -= 1;
            }
            if(other.tag == "Star")
            {
                other.gameObject.SetActive(false);
                playerAudio.PlayOneShot(itemClip);
                GameManager.instance.AddScore(1);
            }
            if (other.tag == "SuperStar")
            {
                other.gameObject.SetActive(false);
                playerAudio.PlayOneShot(itemClip);
                GameManager.instance.AddScore(10);
            }
        }
    }

    private void FeverTime()
    {
        isFever = true;
        animator.SetBool("Fever", isFever);
    }
}
