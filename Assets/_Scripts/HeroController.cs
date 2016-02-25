using UnityEngine;
using System.Collections;

/*
 * Controller class for the Hero
 * @author : Chemcee Cherian , 300793352
 * Created on : 23-02-2016
 * Last modified : 24-02-2016 2250
 * */

//velocity range utility class
[System.Serializable]
public class VelocityRange {

	//PRIVATE INSTANCE VARIABLES
	public float minVelocity;
	public float maxVelocity;

	//PUBLIC INSTANCE VARIABLES

	//CONSTRUCTOR MEHTODS
	public VelocityRange(float min, float max){
		this.maxVelocity = max;
		this.minVelocity = min;	
	}
}

public class HeroController : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;	//this transform variable is to reference the hero gameobject
	private Animator _animator;
	private Rigidbody2D _rigidBody2D;
	private float _move;
	private float _jump;
	private bool _facingRight;
	private bool _isGrounded;

	//PUBLIC INSTANCE VARIABLES
	public VelocityRange velocityRange;
	public float moveForce;
	public float jumpForce;
	public Transform groundCheck;
	public Transform cameraObject;

	// Use this for initialization
	void Start () {
		//initialise public instance variables
		this.velocityRange = new VelocityRange(700f, 5000f);
		this.moveForce = 700f;
		this.jumpForce = 22000f;


		//initialise private instance variables
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		this._move = 0f;
		this._jump = 0f;
		this._facingRight = true;
	}

	void FixedUpdate () {

		Vector3 currentPosition = new Vector3 (this._transform.position.x+150f, this._transform.position.y+0f, -1f);
		this.cameraObject.position = currentPosition;

		this._isGrounded = Physics2D.Linecast (this._transform.position, this.groundCheck.position,
							1 << LayerMask.NameToLayer("ground"));

		float forceX = 0f;
		float forceY = 0f;

		//absolute value of velocity of the gameObject
		float absVelocityX = Mathf.Abs (this._rigidBody2D.velocity.x);
		float absVelocityY = Mathf.Abs (this._rigidBody2D.velocity.y);

		if (this._isGrounded) {

			//gets a number between -1 to 1 for horizontal and vertical axes movement
			this._move = Input.GetAxis ("Horizontal");
			this._jump = Input.GetAxis ("Vertical");

			if (this._move != 0) {
				//if the user want to turn the hero to the right direction
				if (this._move > 0) {	
					if(absVelocityX < this.velocityRange.maxVelocity){
						forceX = this.moveForce;
					}
					this._facingRight = true;
					this._flip ();
				}
				//if the user want to turn the hero to left direction
				if (this._move < 0) { 
					if(absVelocityX < this.velocityRange.maxVelocity){
						forceX = -this.moveForce;
					}
					this._facingRight = false;
					this._flip ();
				}
				//call the hero_walk animation
				this._animator.SetInteger ("AnimState", 1);
			}
			else {
				this._animator.SetInteger ("AnimState", 0);
			}

			if (this._jump > 0) {
				if(absVelocityY < this.velocityRange.maxVelocity){
					forceY = this.jumpForce;
				}
			}
		} else {
			//call the hero_jumb animation
			this._animator.SetInteger ("AnimState", 2);
		}

		//apply the forces
		this._rigidBody2D.AddForce (new Vector2 (forceX, forceY));
	}

	//PRIVATE METHODS

	//method to change the direction of the hero (left or right)
	private void _flip() {
		if (this._facingRight) {
			this._transform.localScale = new Vector2 (2,2);
		}
		else {
			this._transform.localScale = new Vector2 (-2,2);
		}
	}

}