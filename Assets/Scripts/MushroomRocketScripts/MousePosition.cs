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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                   // Instantiate(explosionEffect, raycastHit.transform.position, raycastHit.transform.rotation);
                   // Destroy(raycastHit.transform.gameObject);
                    AsteroidHealth asteroidHealth = raycastHit.transform.GetComponent<AsteroidHealth>();
                    asteroidHealth.TakeDamage(100);

                } else if (raycastHit.transform.GetComponent<InsightMovement>())
                {
                    InsightMovement insightPiece = raycastHit.transform.GetComponent<InsightMovement>();
                    insightPiece.Teleport();
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
