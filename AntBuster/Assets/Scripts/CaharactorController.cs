using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaharactorController : MonoBehaviour
{
    public Animator charactor_Hammer_Animator = default;
    public Animator weapon_Hammer_Animtor = default;    

    public float target = default;
    //public GameObject weaponHammer = default;


    // Start is called before the first frame update
    void Start()
    {
        charactor_Hammer_Animator = GetComponent<Animator>();
        weapon_Hammer_Animtor = weapon_Hammer_Animtor.GetComponentInChildren<Animator>();        
        //weaponHammer = weaponHammer.GetComponentInChildren<GameObject>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            charactor_Hammer_Animator.SetBool("Attack", true);
            weapon_Hammer_Animtor.SetBool("Attack", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 monsterPos = collision.transform.position;

        Debug.Log("¸ó½ºÅÍ¿Í ÅÍ·¿ÀÇ ÁÂÇ¥ : {0}", monsterPos);
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
