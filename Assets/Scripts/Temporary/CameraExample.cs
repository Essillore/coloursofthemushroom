using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExample : MonoBehaviour
{
    public Transform target;
    public float delay = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, target.position, delay * Time.deltaTime);
    }
}
