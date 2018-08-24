using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminTrigger : MonoBehaviour {

	Character cr;
	// Use this for initialization
	void Start () {
		cr = transform.root.gameObject.GetComponent<Character> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(){
		cr.yerdemi = true;
	}

	void OnTriggerStay2D(){
		cr.yerdemi = true;
	}

	void OnTriggerExit2D(){
		cr.yerdemi = false;
	}
}
