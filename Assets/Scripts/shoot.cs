using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speed = 20f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); mouseWorldPos.z = 0f; Vector2 mousePos = mouseWorldPos;
            Vector2 direction = (mousePos - (Vector2)firePoint.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
            if (rb != null) 
            { 
                rb.linearVelocity = direction * speed; Debug.Log("Velocity set: " + (direction * speed)); 
            }
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
            bullet.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            Debug.Log("Direction: " + direction + " | FirePoint: " + firePoint.position);
        }
    }
}
