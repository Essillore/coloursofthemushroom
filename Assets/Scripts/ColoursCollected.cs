using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoursCollected : MonoBehaviour
{
    public Material coloursCollected;
    public Material startingMaterial;
   
    public GameObject insightSpawner;

    Renderer rend;

    public static int i;
    Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        materials = new Material[8];

        materials = rend.materials;
   
        insightSpawner.GetComponent<InsightSpawner>().mushroomCollectingColours = gameObject;
 
        MeshRenderer myRenderer = GetComponent<MeshRenderer>();
        InsightSpawner insightTracker = insightSpawner.GetComponent<InsightSpawner>();
    }
 
    //Assign rainbow colours to inner ring of mushroom hat, corresponding to insight piece collected.
    public void WhichInsightWasCollected(int i)
    {
        materials[i] = coloursCollected;

        // Assign the updated Materials array back to the Renderer component
        GetComponent<Renderer>().materials = materials;
    }


}
