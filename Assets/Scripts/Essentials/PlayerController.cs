using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Mode")]
    public bool twinStick = false;
    public bool mouseAim = false;
    public bool classic = false;

    [Header ("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    public float dep;

    [Header("Shooting")]
    public Transform gun;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public bool canFire = true;



    // Start is called before the first frame update
    void Start()
    {
        if (twinStick)
        {
            gun.GetComponent<TwinStickAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }
        else if (classic)
        {
            gun.GetComponent<TwinStickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = false;
        }
        else if (mouseAim)
        {
            gun.GetComponent<TwinStickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        dep = Input.GetAxis("Depth");
        

        /// This is for moving the player
        transform.Translate( new Vector3(playerSpeed * Time.deltaTime* hor, playerSpeed * Time.deltaTime * ver, playerSpeed * Time.deltaTime * dep));



        /// This is for shooting

        //Input.GetKeyDown(KeyCode G)
        if (!twinStick && Input.GetButtonDown("Fire1") && canFire) 
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;

    }
}
