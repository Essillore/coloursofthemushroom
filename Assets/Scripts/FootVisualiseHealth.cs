using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootVisualiseHealth : MonoBehaviour
{
    public Material footMushroom;
    Material[] materials;

    public int stateOfHealth;
    public int lastStateOfHealth;

    //Materials for different states of player/mushroom health
    public Material footFullWhite100;
    public Material footDamaged80;
    public Material footDamaged60;
    public Material footDamaged40;
    public Material footFullBlack20;
    public Material currentFootMaterial;

    public Renderer footRenderer;

    void Start()
    {
        footRenderer = GetComponent<Renderer>();
        footRenderer.enabled = true;

        materials = new Material[6];
        materials = footRenderer.materials;
    }

    //State of health converts player health (0-100) to switch cases 0-5
    public void CheckIfFootNeedsChanged(float currentHealth)
    {
        stateOfHealth = Mathf.CeilToInt(currentHealth / 20);

        //If player health has crossed the treshold, change foot colour, by changing(material)
        if (stateOfHealth != lastStateOfHealth)
        {
            ChangeFootColour(stateOfHealth);
            lastStateOfHealth = stateOfHealth;
        }
    }
    //Changes foot colour trough changing material to show player health
    public void ChangeFootColour(int stateOfHealth)
    {
        materials[0] = footMushroom;
  
        switch (stateOfHealth)
        {
            case 5:
                print("Full Health");
                currentFootMaterial = footFullWhite100;
                break;
            case 4:
                print("Taken dmg");
                currentFootMaterial = footDamaged80;
                break;
            case 3:
                print("Halfway-ish");
                currentFootMaterial = footDamaged60;
                break;
            case 2:
                print("Not good");
                currentFootMaterial = footDamaged40;
                break;
            case 1:
                print("Almost ded");
                currentFootMaterial = footFullBlack20;
                break;
            case 0:
                print("dead");
                //Possibly instantiate explosion?
                break;
            default:
                Debug.Log("Have you changed the logic or the hp-range?");
                currentFootMaterial = footFullBlack20;
                break;
        }

        //Assign the updated Materials array back to the Renderer component
        GetComponent<Renderer>().material = currentFootMaterial;
    }


}
