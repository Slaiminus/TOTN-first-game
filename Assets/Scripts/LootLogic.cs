using UnityEngine;


public class LootLogic : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private int lootValue;
    private float speed = 1;
    private int time = 50;
    private Rigidbody2D _rb;

    private void Awake()
    {
        gameObject.transform.rotation = Quaternion.identity;
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            // TODO: Player Score += lootValue, maybe do more
            Destroy(gameObject);
        }
    }
}
