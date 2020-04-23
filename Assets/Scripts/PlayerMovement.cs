using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {


	public float dashspeed;
	private float dashtime;
	public float startdashtime;
	private int direction;

	public float chargeTimer;

	public CharacterController2D controller;
	public Animator animator;

	public GameObject textStance;
	// private KeyCode kCode;

	public stanceChoice playerStance = stanceChoice.Neutral;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Start() {
		dashtime = startdashtime;
	}


	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Cancel"))
		{
        SceneManager.LoadScene(0);
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		// foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
		// 	if(Input.GetKey(vKey))
		// 	{
		// 		if (vKey == KeyCode.Return)
		// 		{
		// 			kCode = vKey;
		// 			Debug.Log(kCode);
		// 		}
		// 	}
		// }
		// stanceName = Input.GetButtonDown(); //shitsuxxx
		if (Input.GetButtonDown("Fire1"))
		{
			textStance.GetComponent<TextMesh>().text = "Up Stance";
			playerStance = stanceChoice.Up;
		}
		if (Input.GetButtonDown("Fire2"))
		{

			textStance.GetComponent<TextMesh>().text = "Down Stance";
			playerStance = stanceChoice.Down;
		}
		if (Input.GetButtonDown("Fire3"))
		{

			textStance.GetComponent<TextMesh>().text = "Left Stance";
			playerStance = stanceChoice.Left;
		}
		if (Input.GetButtonDown("Fire4"))
		{

			textStance.GetComponent<TextMesh>().text = "Right Stance";
			playerStance = stanceChoice.Right;
		}
		if (Input.GetButton("Fire5"))
		{
			chargeTimer+=Time.deltaTime;

		}
		if (Input.GetButtonUp("Fire5") && (chargeTimer>2))
		{

			GetComponent<Rigidbody2D>().velocity = new Vector3(90,5,0);
			animator.SetBool("IsJumping", true);
			chargeTimer=0;
		}
		if (Input.GetButtonUp("Fire5") && (chargeTimer<2))
		{
			chargeTimer=0;
		}
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
