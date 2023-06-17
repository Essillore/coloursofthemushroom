using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public Vector3 myPositionAtStart;

    public Vector3 directionVector;
    public Vector3 targetDirection;
    private Vector3 origo;

    public float speed =15f;
    // Start is called before the first frame update
    void Start()
    {
        myPositionAtStart = transform.position;
        origo = new Vector3(0f, 0f, 0f);

    }

    

    // Update is called once per frame
    void Update()
    {
       /* Vector3 directionVector;

        directionVector = (origo + myPositionAtStart);

        float distanceToOrigoAtStart = directionVector.magnitude;

        */
        //Mathf.Asin(b / C);
        // 
    }

    private bool isInTrigger = false;

    public void OnTriggerEnter(Collider other)
    {
        LightMovement lightSphereNear = other.gameObject.GetComponentInParent<LightMovement>();
        
        if (lightSphereNear)
        {
            myPositionAtStart = transform.position;
            directionVector = (origo + myPositionAtStart);
            targetDirection = directionVector.normalized;
            isInTrigger = true;
            StartCoroutine(AnotherLightSphereNear());
        }
    }

    public IEnumerator AnotherLightSphereNear()
    {
        while (isInTrigger)
        {
            // Move the object here
            transform.Translate(speed * Time.deltaTime * targetDirection, Space.World);
            yield return null;
        }

    }


    public void OnTriggerExit(Collider other)
    {
        LightMovement lightSphereNear = other.gameObject.GetComponentInParent<LightMovement>();
  
        if (lightSphereNear)
        {
            isInTrigger = false;
            myPositionAtStart = transform.position;
            directionVector = origo;
            targetDirection = directionVector.normalized;
            StopCoroutine(AnotherLightSphereNear());
        }
        
    }



}
