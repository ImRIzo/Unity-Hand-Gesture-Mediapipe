using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrigger : MonoBehaviour
{
    public bool rightCal { get; set; }
    public GameObject positionReference;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            Debug.Log("right triggered!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            Debug.Log("right triggered Lost!!!");
        }
    }

    public void RightCalibrationToggle()
    {
        rightCal = !rightCal;
        if (!rightCal)
        {
            this.transform.GetChild(0).transform.gameObject.SetActive(false);
            //this.transform.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            this.transform.GetChild(0).transform.gameObject.SetActive(true);
            this.transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void Update()
    {
        if (rightCal)
        {
            if(positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8) != null)
                transform.position = positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8).position;

        }
    }
}
