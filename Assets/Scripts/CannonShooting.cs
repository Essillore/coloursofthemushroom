using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    public GameObject lightBall;
    public float lightBallSpeed = 60000f;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Vector3 aimDir = (MousePosition.GetMouseWorldPosition() - transform.position).normalized;
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(lightBall, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(aimDir * lightBallSpeed);
            GameManager.gameManager.NumberOfShots();
        }
    }

}
