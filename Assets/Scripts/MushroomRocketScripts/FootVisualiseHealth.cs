using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootVisualiseHealth : MonoBehaviour
{
    public Material footMushroom;
    Material[] materials;

    public int stateOfHealth;
    public int lastStateOfHealth;

    //Colours, possibly later replaced with materials
    public Color footFullWhite100;
    public Color footDamaged80;
    public Color footDamaged60;
    public Color footDamaged40;
    public Color footFullBlack20;
    public Color currentFootColour;
    Color debugColor;

    public Renderer footRenderer;

    void Start()
    {
        footRenderer = GetComponent<Renderer>();

        materials = new Material[6];
        CreateColours();
    }

    public void CreateColours()
    {
        //create colours, currents white, greys and black
        //possibly to be replaced with materials

        footFullWhite100 = new Color(1f, 1f, 1f, 1f);
        footDamaged80 = new Color(0.8f, 0.36f, 0.41f, 1f);
        footDamaged60 = new Color(1f, 0.0f, 0.1f, 1f);
        footDamaged40 = new Color(0.53f, 0.0f, 0.06f, 1f);
        footFullBlack20 = new Color(0f, 0f, 0f, 1f);

        debugColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
    }

    public void CheckIfFootNeedsChanged(float currentHealth)
    {
        //ChangeFootColour(currentHealth);
        stateOfHealth = Mathf.CeilToInt(currentHealth / 20);

        if (stateOfHealth != lastStateOfHealth)
        {
            ChangeFootColour(stateOfHealth);
            lastStateOfHealth = stateOfHealth;
        }
    }

    public void ChangeFootColour(int stateOfHealth)
    {
        materials[0] = footMushroom;
        //var footRenderer = GetComponent<Renderer>();
  
        switch (stateOfHealth)
        {
            case 5:
                print("Full Health");
                currentFootColour = footFullWhite100;
                break;
            case 4:
                print("Taken dmg");
                currentFootColour = footDamaged80;
                break;
            case 3:
                print("Halfway-ish");
                currentFootColour = footDamaged60;
                break;
            case 2:
                print("Not good");
                currentFootColour = footDamaged40;
                break;
            case 1:
                print("Almost ded");
                currentFootColour = footFullBlack20;
                break;
            case 0:
                print("dead");
                //Possibly instantiate explosion?
                break;
            default:
                Debug.Log("Have you changed the logic or the hp-range?");
                currentFootColour = debugColor;
                break;
        }
        // Call SetColor using the shader property name "_Color" and setting the color to the custom color you created
        footMushroom.SetColor("_Color", currentFootColour);
        footRenderer.materials = materials;
    }


}
