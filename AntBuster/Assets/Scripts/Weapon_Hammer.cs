using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject hammerObj = default;

    // Start is called before the first frame update
    void Start()
    {
        hammerObj = GetComponent<GameObject>();
    }
}
