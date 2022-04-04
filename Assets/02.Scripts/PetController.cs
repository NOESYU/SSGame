using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip itemClip;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("자석고양이");

        if(other.tag == "Star" || other.tag == "SuperStar")
        {
            if (other.tag == "Star")
            {
                GameManager.instance.AddScore(1);
                playerAudio.PlayOneShot(itemClip);
                other.gameObject.SetActive(false);
            }
            else if(other.tag == "SuperStar")
            {
                GameManager.instance.AddScore(10);
                playerAudio.PlayOneShot(itemClip);
                other.gameObject.SetActive(false);
            }
        }
    }
}
