using UnityEngine;

public class Movement : MonoBehaviour
{
    Transform thisTransform;
    [SerializeField]
    float speed = 5.0f;
    bool moveLeft = false, moveRight = false;
    void Awake()
    {
        thisTransform = transform;
    }
    public void SetMovement(bool left, bool val)
    {
        if (left)
            moveLeft = val;
        else
            moveRight = val;
    }
    void Move(int xValue)
    {
        thisTransform.Translate(new Vector3(xValue, 0, 0) * Time.deltaTime * speed);
    }
    void Update()
    {
        if(moveLeft)
            Move(-1);

        if(moveRight)
            Move(1);
    }
}
