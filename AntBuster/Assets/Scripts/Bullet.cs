using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigid = default;

    public float speed = 7.0f;

    private void Start()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CharactorRifle_Controller target = new CharactorRifle_Controller();

        bulletRigid.velocity = target.result.normalized * speed;
        
    }
}
