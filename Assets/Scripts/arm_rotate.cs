using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class arm_rotate : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = (180 / Mathf.PI) * Mathf.Atan2(mousePos.y - Camera.main.transform.position.y, mousePos.x - Camera.main.transform.position.x);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
