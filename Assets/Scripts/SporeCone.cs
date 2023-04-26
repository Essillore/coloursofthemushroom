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
            print(Time.time);
            StartCoroutine(ChannelDuration());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        InsightMovement insightPiece = other.gameObject.GetComponent<InsightMovement>();
        if (channelReady == true)
        {
            insightPiece.Collect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InsightMovement insightPiece = other.gameObject.GetComponent<InsightMovement>();
        if (insightPiece)
        {
            StopCoroutine(ChannelDuration());
            channelReady = false;
            print("channel stopped");
        }
    }

    private IEnumerator ChannelDuration()
    {
        print("channel started");
        yield return new WaitForSeconds(3);
        print(Time.time);
        
        print("Channeled");
        channelReady = true;
        
        
    }



}
