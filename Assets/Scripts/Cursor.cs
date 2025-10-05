using UnityEngine;

public class Cursor : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.transform.position = worldPos;
    }
}
