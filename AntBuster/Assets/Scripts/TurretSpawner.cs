using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public GameObject hammerIconPrefab = default;
    public GameObject hammerTowerPrefab = default;

    public bool useHand = false;
    public bool isHammer = false;

    GameObject buttonImage;

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
}
