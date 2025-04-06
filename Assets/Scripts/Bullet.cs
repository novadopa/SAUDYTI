using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 10f;
    public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Healthcontrol healthControl = collision.gameObject.GetComponent<Healthcontrol>();
        if (healthControl != null)
        {
            Debug.Log("Applying damage: " + _damageAmount + " to " + collision.gameObject.name);
            healthControl.TakeDamaga(_damageAmount);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);
        Destroy(this.gameObject);
    }
}
