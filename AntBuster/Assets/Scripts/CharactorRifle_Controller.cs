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

    public SpriteRenderer body;
    public SpriteRenderer arm;
    public SpriteRenderer weapon;
    public SpriteRenderer fire;

    public Transform berral = default;

    public GameObject bulletPrefab = default;

    public Vector2 result = Vector2.zero;
    public bool isAttack = false;

    //public GameObject weaponHammer = default;


    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Rifle_Fire").gameObject.SetActive(false);
        charactorRifle_Body = charactorRifle_Body.GetComponentInChildren<Animator>();
        charactorRifle_Arm = charactorRifle_Arm.GetComponentInChildren<Animator>();
        charactorRifle_Weapon = charactorRifle_Weapon.GetComponentInChildren<Animator>();
        charactorRifle_WeaponFire = charactorRifle_WeaponFire.GetComponentInChildren<Animator>();

        body = body.GetComponentInChildren<SpriteRenderer>();
        arm = arm.GetComponentInChildren<SpriteRenderer>();
        weapon = weapon.GetComponentInChildren<SpriteRenderer>();
        fire = fire.GetComponentInChildren<SpriteRenderer>();

    }

    public void OnTriggerStay2D(Collider2D collision)
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

        //if (collision.tag == "Monster")
        //{
        //    transform.Find("Rifle_Fire").gameObject.SetActive(true);

        //    Instantiate(bulletPrefab, berral.position, Quaternion.identity);

        //}

        
        // 왼쪽을 바라봐야 할때
        if ((result.normalized.y > -0.7f && result.normalized.y < 0.7f) && result.normalized.x < 0f || result.normalized.x > 0f)
        {            
            transform.Find("Rifle_Fire").transform.localPosition = new Vector3(-1.4f, 0.5f, 0f);

            if ((result.normalized.y > -0.7f && result.normalized.y < 0.7f) && result.normalized.x > 0f)
            {
                Debug.Log("작동함?");
                body.flipX = true;
                arm.flipX = true;
                weapon.flipX = true;
                fire.flipX = true;
            }
        }
        // 오른쪽을 바라봐야 할때
        //if ((result.normalized.y > -0.7f && result.normalized.y < 0.7f) && result.normalized.x > 0f)
        //{
        //    body.flipX = true;
        //    arm.flipX = true;
        //    weapon.flipX = true;
        //    fire.flipX = true;
        //}
        // 위를 바라봐야 할때
        if ((result.normalized.x > -0.7f && result.normalized.x < 0.7f) && result.normalized.y > 0f)
        {
            transform.Find("Rifle_Fire").transform.localPosition = new Vector3(-0.05f, 2.2f, 0f);
        }
        // 아래를 바라봐야 할때
        if ((result.normalized.x > -0.7f && result.normalized.x < 0.7f) && result.normalized.y < 0f)
        {
            transform.Find("Rifle_Fire").transform.localPosition = new Vector3(+0.05f, -0.9f, 0f);
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            transform.Find("Rifle_Fire").gameObject.SetActive(false);
        }
    }
}
