using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharactorRifle_Controller : MonoBehaviour
{
    public Animator charactorRifle_Body = default;
    public Animator charactorRifle_Arm = default;  
    public Animator charactorRifle_Weapon = default;
    public Animator charactorRifle_WeaponFire = default;

    //public GameObject weaponHammer = default;


    // Start is called before the first frame update
    void Start()
    {
        charactorRifle_Body = charactorRifle_Body.GetComponentInChildren<Animator>();
        charactorRifle_Arm = charactorRifle_Arm.GetComponentInChildren<Animator>();
        charactorRifle_Weapon = charactorRifle_Weapon.GetComponentInChildren<Animator>();
        charactorRifle_WeaponFire = charactorRifle_WeaponFire.GetComponentInChildren<Animator>();
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

        charactorRifle_Body.SetFloat("Xpos", result.normalized.x);
        charactorRifle_Body.SetFloat("Ypos", result.normalized.y);

        charactorRifle_Arm.SetFloat("Xpos", result.normalized.x);
        charactorRifle_Arm.SetFloat("Ypos", result.normalized.y);

        charactorRifle_Weapon.SetFloat("Xpos", result.normalized.x);
        charactorRifle_Weapon.SetFloat("Ypos", result.normalized.y);

        charactorRifle_WeaponFire.SetFloat("Xpos", result.normalized.x);
        charactorRifle_WeaponFire.SetFloat("Ypos", result.normalized.y);

        if (collision.tag == "Monster")
        {
            charactorRifle_Body.SetBool("Attack", true);
            charactorRifle_Arm.SetBool("Attack", true);
            charactorRifle_Weapon.SetBool("Attack", true);
            charactorRifle_WeaponFire.SetBool("Attack", true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            charactorRifle_Body.SetBool("Attack", false);
            charactorRifle_Arm.SetBool("Attack", false);
            charactorRifle_Weapon.SetBool("Attack", false);
            charactorRifle_WeaponFire.SetBool("Attack", false);
        }
    }
}
