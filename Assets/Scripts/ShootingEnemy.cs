using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform fireP;
    public GameObject bullt;
    public float timer;
    public float fireRate = 1f; // Fire every 1 second
    public float bulletOffset = 0.5f; // Move bullet forward slightly

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            timer = 0;
            Shot();
        }
    }

    void Shot()
    {
        // Move spawn point slightly forward
        Vector3 spawnPos = fireP.position + fireP.right * bulletOffset;

        GameObject bullet = Instantiate(bullt, spawnPos, Quaternion.identity);
    }
}
