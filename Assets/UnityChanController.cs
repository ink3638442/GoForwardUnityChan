using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;

	private float groundLevel = -3.0f;

    // Use this for initialization
    void Start()
    {
		this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		this.animator.SetFloat("Horizontal", 1);

		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		this.animator.SetBool("isGround", isGround);
    }
}
