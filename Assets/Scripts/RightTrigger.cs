using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrigger : MonoBehaviour
{
    public CalibrationHandler _calibrationHandler;
    public bool rightCal { get; set; }
    public GameObject positionReference;
    private Vector3 scale;
    public float threshold;
    private void Start()
    {
        scale = transform.localScale;
    }

    private bool canGetTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            if (canGetTrigger)
            {
                canGetTrigger = false;

                if (_calibrationHandler._goTo == CalibrationHandler.GoTo.none)
                {
                    _calibrationHandler._rstate = CalibrationHandler.RState.enter;
                    _calibrationHandler._goTo = CalibrationHandler.GoTo.prev;
                }
                else
                {
                    _calibrationHandler.CheckMovement();
                }
                Debug.Log("right triggered!!!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerPoint"))
        {
            canGetTrigger= true;
            _calibrationHandler._rstate = CalibrationHandler.RState.exit;
            _calibrationHandler.CheckMovement();
            Debug.Log("right triggered Lost!!!");
        }
    }

    public void RightCalibrationToggle()
    {
        rightCal = !rightCal;
        if (!rightCal)
        {
            //this.transform.GetChild(0).transform.gameObject.SetActive(false);
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

            //if (positionReference.transform.GetChild(0) != null)
            //{
            //    Transform thumb = positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4);
            //    Transform index = positionReference.transform.GetChild(0).transform.GetChild(0).transform.GetChild(8);
            //    float distance = Vector3.Distance(thumb.position, index.position);
            //    transform.localScale = new Vector3(scale.x*distance* threshold, scale.y*distance* threshold, scale.z*distance* threshold);
            //}
        }
    }
}
