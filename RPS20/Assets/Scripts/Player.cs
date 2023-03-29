using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public CharContro controller;

	public float runSpeed = 10f;
	public Animator animator;

	float horizontalMove = 0f;
	bool jump = false;
	public bool isControllable = true;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("isJumping", true);
		}

	}

	public void OnLanding()
    {
		animator.SetBool("isJumping", false);
    }

	void FixedUpdate()
	{
		if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
			if (isControllable)
			{
			controller.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, jump);
			jump = false;
			}
		
	}
	public void Die()
    {
		this.enabled = false;
    }
}