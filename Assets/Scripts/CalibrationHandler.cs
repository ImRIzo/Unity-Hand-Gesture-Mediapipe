using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationHandler : MonoBehaviour
{
    public GameObject leftTrigger, rgihttTrigger;


    private void Start()
    {
        if (PlayerPrefs.GetFloat("ltx")!=null)
        {
            Vector3 pos = new Vector3(PlayerPrefs.GetFloat("ltx"), PlayerPrefs.GetFloat("lty"), PlayerPrefs.GetFloat("ltz"));
            leftTrigger.transform.position=pos;
        }
        if (PlayerPrefs.GetFloat("rtx") != null)
        {
            Vector3 pos = new Vector3(PlayerPrefs.GetFloat("rtx"), PlayerPrefs.GetFloat("rty"), PlayerPrefs.GetFloat("rtz"));
            rgihttTrigger.transform.position = pos;
        }
    }

    public void SaveCalibration()
    {
        leftTrigger.transform.GetComponent<BoxCollider>().enabled = true;
        rgihttTrigger.transform.GetComponent<BoxCollider>().enabled = true;

        if (leftTrigger.GetComponent<LeftTrigger>().leftCal == true)
        {
            leftTrigger.GetComponent<LeftTrigger>().leftCal = false;
            PlayerPrefs.SetFloat("ltx", leftTrigger.transform.position.x);
            PlayerPrefs.SetFloat("lty", leftTrigger.transform.position.y);
            PlayerPrefs.SetFloat("ltz", leftTrigger.transform.position.z);
        }
        if (rgihttTrigger.GetComponent<RightTrigger>().rightCal == true)
        {
            rgihttTrigger.GetComponent<RightTrigger>().rightCal = false;
            PlayerPrefs.SetFloat("rtx", rgihttTrigger.transform.position.x);
            PlayerPrefs.SetFloat("rty", rgihttTrigger.transform.position.y);
            PlayerPrefs.SetFloat("rtz", rgihttTrigger.transform.position.z);
        }
    }
}
