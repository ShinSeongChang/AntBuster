using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public GameObject hammerIconPrefab = default;
    public GameObject hammerTowerPrefab = default;

    public GameObject rifleIconPrefab = default;
    public GameObject rifleTowerPrefab = default;

    public bool useHand = false;
    public bool isRifle = false;
    public bool isHammer = false;

    GameObject buttonImage;
    GameObject buttonImage2;


    public void Update()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if (isHammer == true && Input.GetMouseButtonDown(0))
        {            
            Destroy(buttonImage.gameObject);
            Instantiate(hammerTowerPrefab, ray, Quaternion.identity);
            isHammer = false;
            useHand = false;
        }

        if (isRifle == true && Input.GetMouseButtonDown(0))
        {
            Destroy(buttonImage2.gameObject);
            Instantiate(rifleTowerPrefab, ray, Quaternion.identity);
            isRifle = false;
            useHand = false;
        }

    }

    public void PressHammerButton()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if (!useHand)
        {
            buttonImage = Instantiate(hammerIconPrefab, ray, Quaternion.identity);
            isHammer = true;
            useHand = true;
        }
        
    }

    public void PressRiflerButton()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if (!useHand)
        {
            buttonImage2 = Instantiate(rifleIconPrefab, ray, Quaternion.identity);
            isRifle = true;
            useHand = true;
        }

    }
}
