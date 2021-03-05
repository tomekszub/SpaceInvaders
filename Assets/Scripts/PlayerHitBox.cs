using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        gameManager.SubstractPoints();
    }
}
