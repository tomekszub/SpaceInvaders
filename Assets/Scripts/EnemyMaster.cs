using UnityEngine;
using System.Collections.Generic;

public class EnemyMaster : MonoBehaviour
{
    [SerializeField]
    Bolt enemyBoltPrefab;
    [SerializeField]
    float speed = 1.4f;
    [SerializeField]
    EnemyShooting shootingEnemyPrefab;
    [SerializeField]
    Enemy enemyPrefab;

    List<GameObject> enemyBoltsPool = new List<GameObject>();
    Transform thisTransform;
    bool movingLeft = true;
    int rownumber = 4;
    int columnNumber = 8;
    int enemiesCount;

    public int ColumnNumber { get => columnNumber; }

    private void Awake()
    {
        thisTransform = transform;
        enemiesCount = rownumber * columnNumber;
    }
    private void Start()
    {
        float startingfXPos = (ColumnNumber-1) * -0.25f;

        for (int j = 0; j < rownumber; j++)
        {
            for (int i = 0; i < ColumnNumber; i++)
            {
                if(j == 0)
                    Instantiate(shootingEnemyPrefab, new Vector3(startingfXPos + i * 0.5f, 4 - j,0), Quaternion.Euler(new Vector3(180,0,0)), transform);
                else
                    Instantiate(enemyPrefab, new Vector3(startingfXPos + i * 0.5f, 4 - j, 0), Quaternion.Euler(new Vector3(180, 0, 0)), transform);
            }
        }
    }
    private void Update()
    {
        if (thisTransform.position.x <= -0.48f)
            movingLeft = false;
        else if (thisTransform.position.x >= 0.48f)
        {
            thisTransform.Translate(new Vector3(0,-0.3f,0));
            movingLeft = true;
        }

        if (movingLeft)
            thisTransform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        else
            thisTransform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
    }
    public void ShootBolt(Transform boltOrigin)
    {
        GameObject bolt = GetFreeBoltObject();
        if (bolt != null)
        {
            bolt.transform.position = boltOrigin.position;
            bolt.SetActive(true);
        }
        else
        {
            bolt = Instantiate(enemyBoltPrefab.gameObject, boltOrigin.position, Quaternion.identity);
            enemyBoltsPool.Add(bolt);
        }
    }
    GameObject GetFreeBoltObject()
    {
        if (enemyBoltsPool.Count == 0)
            return null;

        foreach (var go in enemyBoltsPool)
        {
            if (!go.activeSelf)
                return go;
        }

        return null;
    }
    public void EnemyDestroyed()
    {
        enemiesCount--;
        if(enemiesCount == 0)
        {
            GetComponent<GameManager>().EndGame();
            return;
        }
        speed += 0.1f;
        foreach (var enemy in GetComponentsInChildren<EnemyShooting>())
        {
            enemy.ShortenCooldown();
        }
    }
    public void ClearEnemies()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
