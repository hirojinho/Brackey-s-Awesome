using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticShooting : MonoBehaviour
{
    private bool beingHandled = false;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float force = 20f;
    public int numBullets;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!beingHandled)
        {
            StartCoroutine(StaticShoot());
        }
    }

    IEnumerator StaticShoot()
    {
        beingHandled = true;
        for(int i = 0; i < numBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.SetParent(gameObject.transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * force, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
        
        yield return new WaitForSeconds(1.5f);
        beingHandled = false;
    }

    void OnEnable()
    {
        beingHandled = false;
    }
}
