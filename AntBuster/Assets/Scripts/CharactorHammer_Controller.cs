using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharactorHammer_Controller : MonoBehaviour
{
    public Animator charactor_Hammer_Animator = default;
    public Animator weapon_Hammer_Animtor = default;  
    //public GameObject weaponHammer = default;


    // Start is called before the first frame update
    void Start()
    {
        charactor_Hammer_Animator = GetComponent<Animator>();
        weapon_Hammer_Animtor = weapon_Hammer_Animtor.GetComponentInChildren<Animator>();               
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 터렛의 좌표.
        Vector2 charactorPos = new Vector2(transform.position.x, transform.position.y);

        // 터렛의 범위 안에 들어와서 움직이는 표적의 좌표.
        Vector2 monsterPos = collision.transform.position;

        // 표적과 터렛의 거리를 저장할 변수 result.
        Vector2 result = Vector2.zero;

        // result 는 터렛에서부터 표적까지의 거리를 계산한다 ==> 목표까지의 거리 = 표적 - 자신
        result = monsterPos - charactorPos;

        //Debug.Log("표적과의 거리");
        //Debug.Log(result);
        //Debug.Log("표적과의 거리, 노멀라이즈드");
        //Debug.Log(result.normalized);

        charactor_Hammer_Animator.SetFloat("Xpos", result.normalized.x);
        charactor_Hammer_Animator.SetFloat("Ypos", result.normalized.y);

        weapon_Hammer_Animtor.SetFloat("Xpos", result.normalized.x);
        weapon_Hammer_Animtor.SetFloat("Ypos", result.normalized.y);

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
