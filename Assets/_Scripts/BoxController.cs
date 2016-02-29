using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//check for the collision of the box with other objects
	void OnCollisionEnter2D(Collision2D other) {		
		if(other.gameObject.CompareTag("death")) {
			//this.gameObject.SetActive (false);
		}
	}
}
