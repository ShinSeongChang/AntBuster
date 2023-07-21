using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaharactorController : MonoBehaviour
{
    public Animator charactor_Hammer_Animator = default;
    public Animator weapon_Hammer_Animtor = default;


    // Start is called before the first frame update
    void Start()
    {
       charactor_Hammer_Animator = GetComponent<Animator>();
       weapon_Hammer_Animtor = weapon_Hammer_Animtor.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            charactor_Hammer_Animator.SetBool("Attack", true);
            weapon_Hammer_Animtor.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            charactor_Hammer_Animator.SetBool("Attack", false);
            weapon_Hammer_Animtor.SetBool("Attack", false);
        }
    }
}
