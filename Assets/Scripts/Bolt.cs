using UnityEngine;

public class Bolt : MonoBehaviour
{
    Transform thisTransform;
    [SerializeField]
    float speed = 1.5f;
    [SerializeField]
    bool goDown = false;
    private void Awake()
    {
        thisTransform = transform;
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        thisTransform.Translate(new Vector3(0, goDown?-1:1, 0) * Time.deltaTime * speed);
    }
}
