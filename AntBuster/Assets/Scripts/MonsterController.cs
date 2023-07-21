using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

    public Rigidbody2D monsterRigid = default;
    private Animator slimeAnimator = default;
    private float speed = 3.0f;

    public bool isRight = false;
    public bool isLeft = false;
    public bool isUp = false;
    public bool isDown = false;


    // Start is called before the first frame update
    void Start()
    {
        monsterRigid = GetComponent<Rigidbody2D>();
        slimeAnimator = GetComponent<Animator>();
        monsterRigid.velocity = Vector2.zero;

        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            monsterRigid.velocity = Vector2.right* speed;            
        }
        if(isLeft)
        {
            monsterRigid.velocity = Vector2.right * -speed;
        }
        if(isUp)
        {
            monsterRigid.velocity = Vector2.up * speed;
        }
        if(isDown)
        {
            monsterRigid.velocity = Vector2.up * -speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Corner_1")
        {
            isRight = false;
            isUp = true;
            slimeAnimator.SetTrigger("Corner_1");
        }
        if (collision.tag == "Corner_2")
        {
            isUp = false;
            isRight = true;
            slimeAnimator.SetTrigger("Corner_2");
        }
        if (collision.tag == "Corner_3")
        {
            isRight = false;
            isDown = true;
            slimeAnimator.SetTrigger("Corner_3");
        }
        if (collision.tag == "Corner_4")
        {
            isDown = false;
            isRight = true;
            slimeAnimator.SetTrigger("Corner_4");
        }
    }
}
