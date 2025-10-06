using UnityEngine;


public class LootLogic : MonoBehaviour
{
    [SerializeField] private string playerTag;
    private float speed = 1;
    private int time = 50;
    private int areFlipped = 1;
    private Rigidbody2D _rb;

    private void Awake()
    {
        gameObject.transform.rotation = Quaternion.identity;
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            // TODO: Player Score += 1, maybe do more
            Destroy(gameObject);
        }
    }
}
