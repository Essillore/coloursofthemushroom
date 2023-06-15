using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCone : MonoBehaviour
{
    public bool channelReady = false;

    void OnEnable()
    {
        Vector3 sporeDirMouse = (MousePosition.GetMouseWorldPosition()- transform.position).normalized;
    }

    private void OnDisable()
    {
        StopCoroutine(ChannelDuration());
    }

    public void OnTriggerEnter(Collider other)
    {
        InsightMovement insightPiece = other.gameObject.GetComponent<InsightMovement>();
        if (insightPiece)
        {
            insightPiece.freeze = true;
            StartCoroutine(ChannelDuration());
        }

        Collectable tutorialSphere = other.gameObject.GetComponent<Collectable>();
        if (tutorialSphere)
        {
            StartCoroutine(ChannelDuration());
            }
    }

    //Currently unused mechanics. Player can collect insight pieces by flying over them.
    //Original intent was to collect them which this sporecone, left the code, it still works, but player
    //will probably collect them in other way.

    private void OnTriggerStay(Collider other)
    {
        InsightMovement insightPiece = other.gameObject.GetComponent<InsightMovement>();
        if (channelReady == true && insightPiece != null)
        {
            insightPiece.Collect();
            Stopping();
        }

        Collectable tutorialSphere = other.gameObject.GetComponent<Collectable>();
        if (channelReady==true && tutorialSphere != null)
        {
            tutorialSphere.Collect();
            Stopping();
        }

    }

    private void Stopping()
    {
        StopCoroutine(ChannelDuration());
        channelReady = false;
    }

    private void OnTriggerExit(Collider other)
    {
        InsightMovement insightPiece = other.gameObject.GetComponent<InsightMovement>();
        if (insightPiece)
        {
            StopCoroutine(ChannelDuration());
            channelReady = false;
        }
        Collectable tutorialSphere = other.gameObject.GetComponent<Collectable>();
        if (tutorialSphere)
        {
            StopCoroutine(ChannelDuration());
            channelReady = false;
        }

    }

    private IEnumerator ChannelDuration()
    {
        yield return new WaitForSeconds(3);   
        channelReady = true;       
    }



}
