using UnityEngine.EventSystems;
using UnityEngine;

public class Arrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    bool isLeftArrow;
    [SerializeField]
    Movement movement;
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        movement.SetMovement(isLeftArrow, true);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        movement.SetMovement(isLeftArrow, false);
    }
}
