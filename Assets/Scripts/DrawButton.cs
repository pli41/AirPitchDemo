using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DrawButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public bool pressed = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

}
