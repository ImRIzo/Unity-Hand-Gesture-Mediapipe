using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationHandler : MonoBehaviour
{
    public GameObject leftTrigger, rgihttTrigger;
    public Toggle toggle;
    public Text text;
    public enum LState
    {
        none,
        enter,
        exit
    }
    public  LState _lstate;
    public enum RState
    {
        none,
        enter,
        exit
    }
    public  RState _rstate;
    public enum GoTo
    {
        none,
        next,
        prev
    }
    public  GoTo _goTo;
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
    public void HandOnOffToggle()
    {
        leftTrigger.transform.GetChild(0).transform.gameObject.SetActive(!toggle);
        rgihttTrigger.transform.GetChild(0).transform.gameObject.SetActive(!toggle);
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

    public void CheckMovement()
    {
        if (!isCRunning) StartCoroutine(ClearData());
        if (_goTo == GoTo.none)
            return;
        if (_goTo == GoTo.next && _lstate == LState.exit)
        {
            Debug.Log("going next page");
            text.text = "going to next page ";
            _goTo = GoTo.none;
            _lstate = LState.none;
        }
        if(_goTo == GoTo.prev && _rstate == RState.exit)
        {
            Debug.Log("previous page");
            text.text = "going back to previous page";
            _goTo = GoTo.none;
            _rstate = RState.none;
        }
    }
    bool isCRunning;
    IEnumerator ClearData()
    {
        isCRunning = true;
        yield return new WaitForSeconds(5);
        _goTo = GoTo.none;
        _lstate= LState.none;
        _rstate= RState.none;
        isCRunning= false;
    }
}
