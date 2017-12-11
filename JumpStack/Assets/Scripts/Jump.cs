using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    public float jumpForce = 7f;
    public Animator animator;
    private bool isGrounded = true;
    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && !GameManager.instance.GetGameOver() && isGrounded)
        {
            //Debug.Log("Jump received");
            isGrounded = false;
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("isJumping");
        }
	}
    public void SetGrounded()
    {
        isGrounded = true;
    }
}
