using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 15f;

    ////  Use[SerializeField] instead of public declaration for the ability to modify in the Inspector


    ///   public Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }


    }

}
