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
        // �ͷ��� ��ǥ.
        Vector2 charactorPos = new Vector2(transform.position.x, transform.position.y);

        // �ͷ��� ���� �ȿ� ���ͼ� �����̴� ǥ���� ��ǥ.
        Vector2 monsterPos = collision.transform.position;

        // ǥ���� �ͷ��� �Ÿ��� ������ ���� result.
        Vector2 result = Vector2.zero;

        // result �� �ͷ��������� ǥ�������� �Ÿ��� ����Ѵ� ==> ��ǥ������ �Ÿ� = ǥ�� - �ڽ�
        result = monsterPos - charactorPos;

        //Debug.Log("ǥ������ �Ÿ�");
        //Debug.Log(result);
        //Debug.Log("ǥ������ �Ÿ�, ��ֶ������");
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
