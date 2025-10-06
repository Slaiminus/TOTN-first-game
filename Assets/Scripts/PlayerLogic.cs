using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))] 
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private string groundTag;
    [SerializeField] private string enemyTag;
    [SerializeField] private int health;

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
    }

    private void Move()
    {
        _rb.linearVelocityX = Input.GetAxis("Horizontal") * speed;
    }
    private void Jump() 
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            health -= 1;
            if (health <= 0)
            {
                RestartScene();
            }
            else
            {
                gameObject.transform.position = nullposition;
            }
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
