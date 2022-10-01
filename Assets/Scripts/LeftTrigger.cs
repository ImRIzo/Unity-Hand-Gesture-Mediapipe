using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrigger : MonoBehaviour
{
    public bool leftCal { get; set; }
    public GameObject positionReference;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            Debug.Log("left triggered!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            Debug.Log("left triggered Lost!!!");
        }
    }

    public void LeftCalibrationToggle()
    {        
        leftCal = ! leftCal;

        if (!leftCal){
            this.transform.GetChild(0).transform.gameObject.SetActive(false);
            //this.transform.GetComponent<BoxCollider>().enabled = true;
        }
        else {
            this.transform.GetChild(0).transform.gameObject.SetActive(true);
            this.transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void Update()
    {
        if (leftCal)
        {
            if (positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8)!=null)
                transform.position = positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).position;
        }
    }
}
