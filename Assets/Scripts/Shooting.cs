using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Transform boltOrigin;
    [SerializeField]
    GameObject boltPrefab;
    [SerializeField]
    float shootingCooldown = 2.0f;

    List<GameObject> boltsPool = new List<GameObject>();
    float currShootingCooldown = 0.0f;
    // Update is called once per frame
    void Update()
    {
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
}
