using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public static MousePosition Instance { get; private set; }

    [SerializeField] private LayerMask mouseColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;

    public GameObject explosionEffect;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 8000f, mouseColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            if(Input.GetButtonDown("Fire1"))
            {
                if (raycastHit.transform.GetComponent<RedAsteroid>() | raycastHit.transform.GetComponent<AsteroidMovement>())
                {
                    AsteroidHealth asteroidHealth = raycastHit.transform.GetComponent<AsteroidHealth>();
                    asteroidHealth.TakeDamage(100);
                } else if (raycastHit.transform.GetComponent<InsightMovement>())
                {
                    InsightMovement insightPiece = raycastHit.transform.GetComponent<InsightMovement>();
                    insightPiece.Teleport();
                } else if (raycastHit.transform.GetComponent<LightHealth>())
                {
                    LightHealth littleLight = raycastHit.transform.GetComponent<LightHealth>();
                    littleLight.TakeDamage(20);
                }
            }
        }

    }
    public static Vector3 GetMouseWorldPosition() => Instance.GetMouseWorldPosition_Instance();

    private Vector3 GetMouseWorldPosition_Instance()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 3000f, mouseColliderLayerMask))
        {
            return raycastHit.point;
        } else
        {
            return Vector3.zero;
        }
    }
}
