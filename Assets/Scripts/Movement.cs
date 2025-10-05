using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))] 
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private string groundTag;
    [SerializeField] private string enemyTag;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Rigidbody2D _rb;
    private bool isGrounded;
    private UnityEngine.Vector3 nullposition;


    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        nullposition = transform.position;
    }

    private void Update()
    {
        Jump();
        Move();
        Shoot();
    }

    private void Move()
    {
        _rb.linearVelocityX = Input.GetAxis("Horizontal") * speed;
    }
    private void Jump() 
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, firePoint);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag(enemyTag))
        {
            RestartScene();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
}
