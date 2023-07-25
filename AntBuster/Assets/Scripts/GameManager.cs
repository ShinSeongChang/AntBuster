using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    public bool isGameover = false;
    public Text goldText = default;

    public int gold = 500;

    public bool isHammer = false;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("�� �� �̻��� ���ӸŴ����� ����");
            Destroy(gameObject);
        }
    }



}
