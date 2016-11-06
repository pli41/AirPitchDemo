using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AirDraw : MonoBehaviour {

    [SerializeField]
    GameObject trail;
    GameObject currentTrail;

    [SerializeField]
    Transform savedTrailsObj;
    List<TrailRenderer> savedTrails;

    [SerializeField]
    DrawButton drawBtn;


	// Use this for initialization
	void Start () {
        StartCoroutine("InputListener");
        savedTrails = new List<TrailRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void StartDraw()
    {
        
        if (currentTrail)
        {
            return;
        }
        DebugLog.AddLog("StartDraw");
        currentTrail = Instantiate(trail, transform.position, transform.rotation, transform) as GameObject;
        currentTrail.GetComponent<TrailRenderer>().material.color = ColorPicker.GetCurrentColor();
    }

    void EndDraw()
    {
        
        if (!currentTrail)
        {
            return;
        }
        
        savedTrails.Add(currentTrail.GetComponent<TrailRenderer>());
        currentTrail.transform.SetParent(savedTrailsObj);
        currentTrail = null;
        DebugLog.AddLog("EndDraw; " + savedTrails.Count + " trails saved");
    }

    IEnumerator InputListener()
    {
        while (true)
        {
            Debug.Log("Checking");
            
            if (drawBtn.pressed)
            {
                StartDraw();
            }
            else
            {
                EndDraw();
            }

            /*
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    currentFingerId = touch.fingerId;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    if (touch.fingerId == currentFingerId)
                    {

                    }
                }
            }
            */
            yield return null;
        }
        
    }

}
