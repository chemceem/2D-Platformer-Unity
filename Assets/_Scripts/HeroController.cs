﻿using UnityEngine;
using System.Collections;

/*
 * Controller class for the Hero
 * @author : Chemcee Cherian , 300793352
 * Created on : 23-02-2016
 * */
public class HeroController : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Animator _animator;
	private float _move;
	private float _jump;
	private bool _facingRight;


	//PUBLIC INSTANCE VARIABLES

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._move = 0f;
		this._jump = 0f;
		this._facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		this._move = Input.GetAxis ("Horizontal");
		this._jump = Input.GetAxis ("Vertical");
		if (this._move != 0) {
			//call the hero_walk animation

			if(this._move > 0 ) {	//hero is facing to the right side
				this._facingRight = true;
				this._flip ();
			}

			if (this._move < 0) { //hero is facing to the left side
				this._facingRight = false;
				this._flip ();
			}

			this._animator.SetInteger ("AnimState", 1);
		} else {			
			this._animator.SetInteger ("AnimState", 0);
		}

		if (this._jump > 0) {
			//call the hero_jumb animation
			this._animator.SetInteger ("AnimState", 2);
		}
	}

	//PRIVATE METHODS
	private void _flip() {
		if (this._facingRight) {
			this._transform.localScale = new Vector2 (2,2);
		}
		else {
			this._transform.localScale = new Vector2 (-2,2);
		}

	}	
}