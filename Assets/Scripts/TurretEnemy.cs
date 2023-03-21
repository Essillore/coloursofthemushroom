using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public Transform target;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

    }

    public void Shoot()
    {
        print("Shoot");
        Instantiate(bullet, transform.position, transform.rotation);
        /// GameObject myBullet =
        /// myBullet.GetComponent<EnemyBulletScript>();


    }
}
