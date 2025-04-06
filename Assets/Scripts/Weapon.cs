using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField]
    private float _damageAmout;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    void Update()
    {
        if (PauseMenu.isPaused) return;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyControl>())
        {
            Healthcontrol healthControl = collision.gameObject.GetComponent<Healthcontrol>();
            if (healthControl != null)
            {
                healthControl.TakeDamega(_damageAmout);
            }
        }

    }
}