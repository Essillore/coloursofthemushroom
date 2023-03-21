using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    public float dep;

    [Header ("Shooting")]
    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        print("Shoot");
        Instantiate(bullet, transform.position, transform.rotation);


    }
}
