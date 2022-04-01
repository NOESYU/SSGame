using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Star" | other.tag == "SuperStar")
        {
            Debug.Log("고양이 닿음");
        }
    }
}
