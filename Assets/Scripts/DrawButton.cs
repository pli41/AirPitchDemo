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
		
	void LateUpdate(){
		
	}

	public void PressButton(){
		pressed = true;
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
		DebugLog.AddLog("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        DebugLog.AddLog("OnPointerUp");
    }

}
