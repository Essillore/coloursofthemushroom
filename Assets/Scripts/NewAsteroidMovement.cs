using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAsteroidMovement : MonoBehaviour
{
        public Transform centerOfOrbit;
        public float orbitSpeed = 10f;
        public float forceToAdd;
        public float radius = 1;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 orbitCenter = centerOfOrbit.position;
            Vector3 orbitNormal = Vector3.up;

            Vector3 toOrbitCenter = transform.position - orbitCenter;
            Vector3 orbitDirection = Vector3.Cross(toOrbitCenter, orbitNormal).normalized;

            float distanceToCenter = toOrbitCenter.magnitude;
            float angle = orbitSpeed * Time.fixedDeltaTime / radius;

            Vector3 newOrbitPosition = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, orbitDirection) * toOrbitCenter;
            Vector3 newPosition = orbitCenter + newOrbitPosition;

            Vector3 velocity = (newPosition - transform.position) / Time.fixedDeltaTime;
            rb.velocity = velocity;

            forceToAdd = rb.mass * (velocity.magnitude * velocity.magnitude) / distanceToCenter;

            Vector3 forceVector = -toOrbitCenter.normalized * forceToAdd;
            rb.AddForce(forceVector, ForceMode.Force);
        }
    }
