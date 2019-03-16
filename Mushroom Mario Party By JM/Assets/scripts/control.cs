using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

	public Animator Anim;
	public float WalkSpeed;
	Rigidbody rg;
	Transform tr;
	private float rotY = 0f;
	private float rotX = 0f;
	
	public float speed = 2;
	public float rotationSpeed = 25;
	public float jumpForce = 25;
	public float minAngle = -70;
	public float maxAngle = 90;
	
	public Vector2 newSpeed;
	
	public bool onGround = false;
	public bool jumping = false;
	
	// Use this for initialization
	void Start () {
		tr = this.transform;
		rg = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	/*void Update () {
		PlayerControl();
		
		
		
			
	}*/
	void FixedUpdate () {
		PlayerControl();
		//AnimControl();
		
		
			
	}
	private void PlayerControl2(){
		Vector3 sp = rg.velocity;
		
		float deltaX = Input.GetAxis("Horizontal");
		float deltaZ = Input.GetAxis("Vertical");
		float deltaT = Time.deltaTime;
		newSpeed = new Vector2(deltaX,deltaZ);
		
		Vector3 side = speed * deltaX * deltaT * tr.right;
		Vector3 forward = speed * deltaZ * deltaT * tr.forward;
		
		Vector3 endSpeed = side + forward;
		
		rg.velocity = endSpeed;
	}
	
	private void AnimControl(){
		Anim.SetFloat("X", newSpeed.x);
		Anim.SetFloat("Y", newSpeed.y);
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
			Anim.SetBool("correr",true);
			transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
		}
	}
	
	private void PlayerControl(){
		
		if(Input.GetKey(KeyCode.Space)){
			jumping = true;
			RaycastHit hit;
			onGround = Physics.Raycast(tr.position,-tr.up,out hit, .1f);
			
			if(onGround){
				if(jumping){
					rg.AddForce(tr.up* jumpForce);
					
				}
			}
		}else{
			jumping = false;
		}
		
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
		}else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
		}else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(135, Vector3.up);
		}else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(225, Vector3.up);
		}else if(Input.GetKey(KeyCode.W)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
		}else if (Input.GetKey(KeyCode.S)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
		}else if (Input.GetKey(KeyCode.A)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
		}else if (Input.GetKey(KeyCode.D)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
		}else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)){
			Anim.SetBool("correr",true);
			transform.Translate(Vector3.forward*WalkSpeed*Time.deltaTime);
			transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
		}else{
			Anim.SetBool("correr",false);
		}
	}
}
