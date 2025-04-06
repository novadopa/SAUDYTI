using UnityEngine;
using System.Collections;

public class EneBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public GameObject hitEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure your player has the 'Player' tag.");
            Destroy(gameObject);
            return;
        }

        // Calculate and apply velocity
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * force;

        // Prevent collision with the shooter for a short time
        Collider2D bulletCollider = GetComponent<Collider2D>();
        Collider2D shooterCollider = transform.parent ? transform.parent.GetComponent<Collider2D>() : null;

        if (shooterCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, shooterCollider);
            StartCoroutine(EnableCollisionAfterDelay(bulletCollider, shooterCollider, 0.2f));
        }
    }

    private IEnumerator EnableCollisionAfterDelay(Collider2D bullet, Collider2D shooter, float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreCollision(bullet, shooter, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Instantiate hit effect if assigned
        if (hitEffect != null)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                var healthControl = collision.gameObject.GetComponent<Healthcontrol>();
                healthControl.TakeDamega(_damageAmout);
            }
        }

        // Destroy bullet on valid collision
        Destroy(gameObject);
    }
    [SerializeField]
    private float _damageAmout;
}
