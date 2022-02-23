using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float force = 20f;
    public IEnumerator Shoot()
    {
        gameObject.GetComponent<EnemyRotation>().beingHandled = true;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.SetParent(gameObject.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1);

        gameObject.GetComponent<EnemyRotation>().beingHandled = false;
    }

    void OnEnable()
    {
        gameObject.GetComponent<EnemyRotation>().beingHandled = false;
    }
}
