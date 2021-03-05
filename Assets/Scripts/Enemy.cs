using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<PlayerHitBox>() != null)
        {
            GetComponentInParent<GameManager>().SubstractPoints();
        }
        else
        {
            other.gameObject.SetActive(false);
            GetComponentInParent<GameManager>().AddPoint();
        }
        GetComponentInParent<EnemyMaster>().EnemyDestroyed();
        Destroy(gameObject);
    }
}
