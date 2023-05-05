using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCone : MonoBehaviour
{
    public float channelStart;
    public bool channelReady = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void OnEnable()
    {
        Vector3 sporeDirMouse = (MousePosition.GetMouseWorldPosition()- transform.position).normalized;
        //transform.rotation = Quaternion.LookRotation(sporeDirMouse, Vector3.up);

        //Quaternion.LookRotation(sporeDir, Vector3.up)
        //Quaternion.Euler(1.5f, 0f, 0f);
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
           channelStart = Time.time;
            insightPiece.freeze = true;
         //   print(Time.time);
            StartCoroutine(ChannelDuration());
        }

        Collectable tutorialSphere = other.gameObject.GetComponent<Collectable>();
        if (tutorialSphere)
        {
            channelStart = Time.time;
            StartCoroutine(ChannelDuration());
            }
    }

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
            insightPiece.freeze = false;
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
