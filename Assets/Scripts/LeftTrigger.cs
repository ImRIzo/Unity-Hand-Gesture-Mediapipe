using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrigger : MonoBehaviour
{
    public CalibrationHandler _calibrationHandler;
    public bool leftCal { get; set; }
    public GameObject positionReference;
    public float threshold;
    private Vector3 scale;
    private void Start()
    {
        scale = transform.localScale;
    }
    private bool canGetTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (canGetTrigger)
        {
            canGetTrigger = false;
            if(_calibrationHandler._goTo== CalibrationHandler.GoTo.none)
            {
                _calibrationHandler._lstate = CalibrationHandler.LState.enter;
                _calibrationHandler._goTo = CalibrationHandler.GoTo.next;
            }
            else
            {
                _calibrationHandler.CheckMovement();
            }
            Debug.Log("left triggered!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            canGetTrigger = true;
            _calibrationHandler._lstate = CalibrationHandler.LState.exit;
            _calibrationHandler.CheckMovement();
            Debug.Log("left triggered Lost!!!");
        }
    }

    public void LeftCalibrationToggle()
    {        
        leftCal = ! leftCal;

        if (!leftCal){
            //this.transform.GetChild(0).transform.gameObject.SetActive(false);
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

            //if (positionReference.transform.GetChild(0) != null)
            //{
            //    Transform thumb = positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4);
            //    Transform index = positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8);
            //    float distance = Vector3.Distance(thumb.position, index.position);
            //    transform.localScale = new Vector3(scale.x * distance* threshold, scale.y * distance* threshold, scale.z * distance* threshold);
            //}
        }
    }
}
