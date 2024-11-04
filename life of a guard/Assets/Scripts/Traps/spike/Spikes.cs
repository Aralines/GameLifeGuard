using UnityEngine;
using UnityEngine.Serialization;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float damage = 0.2f;
    [FormerlySerializedAs("pushForce")] [SerializeField] private float pushPower = 0f;

    private const string PLAYERTAG = "Player";
    private const string ENEMYTAG = "Enemy";
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInfo info;
        if (other.CompareTag(PLAYERTAG) ||
            other.CompareTag(ENEMYTAG))
        {
            info = other.GetComponent<PlayerInfo>();
            info.TakeDamage(damage);

            if (pushPower > 0)
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Направление от шипов к игроку
                    Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                    // Применяем силу в направлении
                    rb.AddForce(pushDirection * pushPower, ForceMode2D.Impulse);
                }
            }
        }
    }
}
