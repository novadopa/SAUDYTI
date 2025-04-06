using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using JetBrains.Annotations;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    public Transform player;
    void Update()
    {
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Make the enemy always look at the player
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);


    }
}