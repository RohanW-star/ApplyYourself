using UnityEngine;
using UnityEngine.EventSystems;

public class OverUIBLocker : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public static bool IsPointerOverUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsPointerOverUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPointerOverUI = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPointerOverUI = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPointerOverUI = false;
    }
}
