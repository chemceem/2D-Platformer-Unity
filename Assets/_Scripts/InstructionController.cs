using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionController : MonoBehaviour {
	
	/*
 * Controller class for the Hero
 * @author : Chemcee Cherian , 300793352
 * Created on : 29-02-2016
 * Last modified : 29-02-2016 
 * Description : Class to display the instructions on the screen
 * */

	//PUBLIC INSTANCE VARIABLES
	public Button menuButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//to go back to the start screen
	public void ShowMenu(){
		SceneManager.LoadScene ("start");
	}
}
