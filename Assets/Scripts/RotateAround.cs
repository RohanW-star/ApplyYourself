using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float speed;

    private bool isRotating = false;

    private float startMousePosition;

    public float timer = 0.1f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer -= Time.deltaTime;
            if (timer <= 0 )
            {
                if (!isRotating)
                {
                    startMousePosition = Input.mousePosition.x;
                    isRotating = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            timer = 0.1f;
            isRotating = false;
        }

        if (isRotating)
        {
            float currentMousePosition = Input.mousePosition.x;
            float mouseMovement = currentMousePosition - startMousePosition;
            Debug.Log(mouseMovement);

            transform.Rotate(Vector3.up, mouseMovement * speed * Time.deltaTime);
            startMousePosition = currentMousePosition;
        }
    }
}
