using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSample : MonoBehaviour
{
    [Range(10f, 100f)]
    public float drivingSpeed = 1f;
    [Range(10f, 100f)]
    public float rotateSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {

        // m‰‰rit‰ kappaleen sijainti
        transform.position = new Vector3(0f, 0f, 0f);

        // hyvin harvoin ohjaistetaan rotaatiota suoraan n‰in
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = Quaternion.Euler(1f, 2f, 3f);


        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        transform.Translate(Vector3.right * ver * drivingSpeed * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.up, hor * rotateSpeed * Time.deltaTime);
        // transform.Rotate(Vector3.up, 1f * Time.deltaTime);

        //transform.Translate(Vector3.forward * drivingSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.forward, hor * rotateSpeed * Time.deltaTime);
    }
}
