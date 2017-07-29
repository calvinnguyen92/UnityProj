using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackController : MonoBehaviour {
    
    private static bool isSelected = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
            

        //}
	}

    void selectingStack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isSelected == true)
            {
                isSelected = false;
            }
            else
            {
                Debug.Log("Mouse Clicked");
                isSelected = true;
            }
        }
    }
}
