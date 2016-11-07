using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugLog : MonoBehaviour {

    static Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void AddLog(string log )
    {
        if (!text)
        {
            return;
        }
        text.text += log + System.Environment.NewLine;
    }
}
