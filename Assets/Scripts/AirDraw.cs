using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AirDraw : MonoBehaviour {

    [SerializeField]
    GameObject trail;
    GameObject currentTrail;

    [SerializeField]
    Transform savedTrailsObj;
    List<TrailRenderer> savedTrails;




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
        currentTrail = Instantiate(trail, transform.position, transform.rotation, transform) as GameObject;
    }

    void EndDraw()
    {
        savedTrails.Add(currentTrail.GetComponent<TrailRenderer>());
        currentTrail.transform.SetParent(savedTrailsObj);

    }

    


    IEnumerator InputListener()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("123");
                StartDraw();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                EndDraw();
            }

            yield return null;
        }
        
    }

}
