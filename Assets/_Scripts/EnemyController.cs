using UnityEngine;
using System.Collections;

/*
 * Controller class for the Hero
 * @author : Chemcee Cherian , 300793352
 * Created on : 29-02-2016
 * Last modified : 29-02-2016 
 * Description : Class that controls the enemy movemenst
 * */

public class EnemyController : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
	private bool _isGrounded;
	private Transform _transform;	
	private float moveForce;
	private float velocity;
	private float _width;
	private Rigidbody2D _enemyRigidBody;

	//PUBLIC INSTANCE VARIABLES
	public Transform groundCheck;
	public LayerMask enemyMask;

	// Use this for initialization
	void Start () {
		this._transform = this.transform;
		//this._transform = gameObject.GetComponent<Transform> ();
		this._enemyRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		this._width = gameObject.GetComponent<SpriteRenderer> ().bounds.extents.x;	//to get width of sprite

	}
	
	// Update is called once per frame
	void FixedUpdate () { 	

		//to move the enemy forward at all times


		/*this._isGrounded = Physics2D.Linecast (this._transform.position, this.groundCheck.position,
			1 << LayerMask.NameToLayer("ground"));
		if (this._isGrounded) {
			Vector2 enemyVelocity = this._enemyRigidBody.velocity;
			enemyVelocity.x = this._transform.right.x *  25f;
			this._enemyRigidBody.velocity = enemyVelocity;
		}
		if (!this._isGrounded) {
			Vector2 enemyVelocity = this._enemyRigidBody.velocity;
			enemyVelocity.x = -this._transform.right.x *  25f;
			this._enemyRigidBody.velocity = enemyVelocity;
		} */


	}

}
