using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigid = default;

    public float speed = 7.0f;

    private void Start()
    {
        Debug.Log("동작하나");

        CharactorRifle_Controller target = new CharactorRifle_Controller();

        bulletRigid = GetComponent<Rigidbody2D>();

        bulletRigid.velocity = target.result * speed;
        
    }

}
