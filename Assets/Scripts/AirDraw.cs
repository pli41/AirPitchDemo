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
        currentTrail = Instantiate(trail, transform.position, transform.rotation, transform) as GameObject;
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
            yield return null;
        }
        
    }

}
