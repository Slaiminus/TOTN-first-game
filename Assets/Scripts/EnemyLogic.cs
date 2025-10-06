using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private double time;
    [SerializeField] private string damageTag;
    [SerializeField] private int health;
    [SerializeField] private GameObject lootPrefab;
    [SerializeField] private GameObject lootPrefab2;
    [SerializeField] private GameObject lootPrefab3;
    private int rand;
    private int areFlipped = 1;
    private Rigidbody2D _rb;
    private double startTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        startTime = time;
    }

    void Update()
    {
        Debug.Log(areFlipped);
        Debug.Log(time);
        _rb.linearVelocityX = areFlipped * speed;
        time -= 1;
        if (time < 0)
        {
            areFlipped *= -1;
            time = startTime;
            if (gameObject.transform.localScale.y > 0)
            { gameObject.transform.localScale = gameObject.transform.localScale + Vector3.up * -2; }
            else { gameObject.transform.localScale = gameObject.transform.localScale + Vector3.up * 2; }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(damageTag))
        { health -= 1;
            if (health <= 0)
            {
                rand = Random.Range(0, 6);
                if (rand < 3)
                { Instantiate(lootPrefab, gameObject.transform.position, Quaternion.identity); }
                else if (rand < 5)
                { Instantiate(lootPrefab2, gameObject.transform.position, Quaternion.identity); }
                else { Instantiate(lootPrefab3, gameObject.transform.position, Quaternion.identity); }
                Destroy(gameObject);
            }
        }
    }
}
