using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))] 
public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private string groundTag;
    [SerializeField] private string enemyTag;
    [SerializeField] public int maxhealth;
    [SerializeField] private TMP_Text counter;
    [SerializeField] private Slider hpbar;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private shoot shoot;


    public int health;


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
        health = maxhealth;
        _rb = GetComponent<Rigidbody2D>();
        nullposition = transform.position;
    }

    private void Update()
    {
        Jump();
        Move();
        settings();
    }
    public bool paused; 
    public void setpaused(bool paused) 
    { 
        this.paused = paused;
    }
    private void settings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        Time.timeScale = paused ? 0.0f : 1.0f;
        counter.gameObject.SetActive(!paused);
        hpbar.gameObject.SetActive(!paused);
        shoot.enabled = !paused;
        button1.gameObject.SetActive(paused);
        button2.gameObject.SetActive(paused);
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
