using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    float minShootingCooldown = 4.0f;
    [SerializeField]
    float maxShootingCooldown = 7.0f;
    float currShootingCooldown = 0.0f;
    EnemyMaster enemyMaster;
    [SerializeField]
    Transform boltOrigin;

    private void Awake()
    {
        enemyMaster = GetComponentInParent<EnemyMaster>();
        SetCooldown();
    }
    void Update()
    {
        if (currShootingCooldown > 0)
            currShootingCooldown -= Time.deltaTime;
        else
        {
            enemyMaster.ShootBolt(boltOrigin);
            SetCooldown();
        }
    }
    void SetCooldown()
    {
        currShootingCooldown = Random.Range(minShootingCooldown, maxShootingCooldown);
    }
    public void ShortenCooldown()
    {
        minShootingCooldown -= 0.2f;
        maxShootingCooldown -= 0.2f;
    }
}
