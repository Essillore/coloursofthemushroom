using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITutorial : MonoBehaviour
{
    public TMP_Text tutorialProgress;
    public GameObject tutorialBG;
    public int i = 0;
    public bool[] activatedYet;
    //  public int[] tutorialSnippet;

    // Start is called before the first frame update
    void Start()
    {
        tutorialProgress.text = UIFlyForwards(0);


        activatedYet = new bool[8];

       // tutorialSnippet = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
    //    UIFlyForwards(i);
        //tutorialProgress.text = UIFlyForwards(i);


            if (i==0 && (activatedYet[0] == false) && Input.GetButtonDown("Vertical"))
            {
            StartCoroutine(TutorialText());
           // i++;
             //   activatedYet[0] = true;
            }
            if (i == 1 && (activatedYet[1] == false) && Input.GetButtonDown("Horizontal"))
            {
            StartCoroutine(TutorialText());

            //i++;
            //  activatedYet[1] = true;
        }
            if (i == 2 && (activatedYet[2] == false) && Input.GetButtonDown("Depth"))
            {
            StartCoroutine(TutorialText());
            //   i++;
            // activatedYet[2] = true;
        }
            if (i ==3 && (activatedYet[3] == false) && Input.GetButtonDown("Fire1"))
            {
            StartCoroutine(TutorialText());
            // i++;
            //  activatedYet[3] = true;
        }
            if (i == 4 && (activatedYet[4] == false) && Input.GetButtonDown("Fire2"))
            {
            StartCoroutine(TutorialText());
            //            i++;
            //              activatedYet[4] = true;
        }
            if (i == 5 && (activatedYet[5] == false) && Input.GetButtonDown("Roll"))
            {
            StartCoroutine(TutorialText());
            //i++;
            //  activatedYet[5] = true;
        }
            if (i == 6)
            {
            tutorialBG.SetActive(false);
            }
        
    }

    public string UIFlyForwards(int whichToDisplay)
    {
        if (whichToDisplay == 0)
        { 
            return "Fly with [space]";
        }
        if (whichToDisplay == 1)
        {
            return "Turn (yaw) with [AD]";
        }
        if (whichToDisplay == 2)
        {
            return "Turn (pitch) with [WS]";
        }
        if (whichToDisplay == 3)
        {
            return "Shoot with [left click]" +
                "\n" + "or [x]";
        }
        if (whichToDisplay == 4)
        {
            return "Hold [right mouse button]" + 
                "\n" + "or [left alt] " + "to collect";
        }
        if (whichToDisplay == 5)
        {
            return "Roll with [QE]";
        }
        else
        {
            return " ";
        }
    }
    public IEnumerator TutorialText()
    {
        float waitTime = 1f;

        yield return new WaitForSeconds(waitTime / 3);
        activatedYet[i] = true;
        tutorialProgress.text = "Great!";
        yield return new WaitForSeconds(waitTime);
        tutorialProgress.text = " ";
        yield return null;
        i++;
        UIFlyForwards(i);
        tutorialProgress.text = UIFlyForwards(i);
    }
        /*
            for (i=0; i<6;)
            {
                tutorialProgress.text = UIFlyForwards(i);
                if (Input.GetButtonDown("Vertical"))
                {
                    tutorialProgress.text = "Great!";
                    yield return new WaitForSeconds(waitTime);
                    tutorialProgress.text = " ";
                    i++;
                    UIFlyForwards(i);
                    tutorialProgress.text = UIFlyForwards(i);
                }
                if (i==1 && Input.GetButtonDown("Horizontal"))
                {
                    tutorialProgress.text = "Great!";
                    yield return new WaitForSeconds(waitTime);
                    tutorialProgress.text = " ";
                    i++;
                }
                if (i == 2 && Input.GetButtonDown("Depth"))
                {
                    tutorialProgress.text = "Great!";
                    yield return new WaitForSeconds(waitTime);
                    tutorialProgress.text = " ";
                    i++;
                }
                if (i == 3 && Input.GetButtonDown("Fire1"))
                {
                    tutorialProgress.text = "Great!";
                    yield return new WaitForSeconds(waitTime);
                    tutorialProgress.text = " ";
                    i++;
                }
                if (i == 4 && Input.GetButtonDown("Fire2"))
                {
                    tutorialProgress.text = "Great!";
                    yield return new WaitForSeconds(waitTime);
                    tutorialProgress.text = " ";
                    i++;
                }
                if (i == 5 && Input.GetButtonDown("Roll"))
                {
                    tutorialProgress.text = "Great!";
                    yield return new WaitForSeconds(waitTime);
                    tutorialProgress.text = " ";
                    i++;
                }

            }

        }
        */
    }
