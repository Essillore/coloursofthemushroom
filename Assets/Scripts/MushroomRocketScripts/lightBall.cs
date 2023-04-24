using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBall : MonoBehaviour
{
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //print(this.GetComponent<Rigidbody>().velocity.magnitude.ToString());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RedAsteroid>() | collision.gameObject.GetComponent<AsteroidMovement>()) 
        {
            Instantiate(explosionEffect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
    }
}
