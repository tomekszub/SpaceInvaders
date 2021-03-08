using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Button boostButton;
    [SerializeField]
    TMPro.TMP_Text boosterText;
    [SerializeField]
    Transform boltOrigin;
    [SerializeField]
    GameObject boltPrefab;
    [SerializeField]
    float shootingCooldown = 2.0f;
    [SerializeField]
    float boosterCooldown = 40.0f;
    [SerializeField]
    float boosterDuration = 5.0f;

    List<GameObject> boltsPool = new List<GameObject>();
    float currShootingCooldown = 0.0f;
    float currBoosterCooldown = 0;
    bool boosterReady = false;
    bool boostActive = false;

    void Update()
    {
        if (!boosterReady)
            ManageBooster();
        if (currShootingCooldown > 0)
            currShootingCooldown -= Time.deltaTime;
        else
        {
            GameObject bolt = GetFreeBoltObject();
            if (bolt != null)
            {
                bolt.transform.position = boltOrigin.position;
                bolt.SetActive(true);
            }
            else
            {
                bolt = Instantiate(boltPrefab, boltOrigin.position, Quaternion.identity);
                boltsPool.Add(bolt);
            }

            currShootingCooldown = shootingCooldown;
        }

    }
    GameObject GetFreeBoltObject()
    {
        if (boltsPool.Count == 0) 
            return null;

        foreach (var go in boltsPool)
        {
            if (!go.activeSelf)
                return go;
        }

        return null;
    }

    public void ActivateBoost()
    {
        boosterReady = false;
        boostActive = true;
        boostButton.interactable = false;
        currBoosterCooldown = boosterCooldown;
        boosterText.text = currBoosterCooldown.ToString();
        shootingCooldown /= 2;
    }

    void ManageBooster()
    {
        if (currBoosterCooldown > 0)
        {
            currBoosterCooldown -= Time.deltaTime;
            boosterText.text = ((int)currBoosterCooldown).ToString();
            if(boostActive == true && currBoosterCooldown <= boosterCooldown-boosterDuration)
            {
                boostActive = false;
                shootingCooldown *= 2;
            }
        }
        else
        {
            boosterReady = true;
            boosterText.text = "";
            boostButton.interactable = true;
        }
    }
}
