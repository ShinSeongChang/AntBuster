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
