﻿using UnityEngine;
using System.Collections;

public class ButtonObjectBehaviour : ObjectsBehaviour {
	private bool _pressed;
	
	public bool IsPressed {
		get { return _pressed; }
		set {
			if (value == true && !_pressed)
				animator.SetBool("Pressed", true);
			if (value == false && _pressed)
				animator.SetBool("Pressed", false);
				
			_pressed = value;
		}
	}
	
	protected override void Start() {
		base.Start ();
		_pressed = false;
	}

	/*
	protected override void ChangedToHappy() {
		//rigidbody2D.isKinematic = false;
		rigidbody2D.mass = 1000;
	}
	
	protected override void ChangedToSad() {
		//rigidbody2D.isKinematic = true;
		rigidbody2D.mass = 20;
	}
	*/

	protected virtual void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player" && !IsPressed) {
			if (currentState() == GameStateBehaviour.STATES.Sad) {
				IsPressed = true;
			}
			/*
			else if(currentState() == GameStateBehaviour.STATES.Happy)
			{
				IsPressed = false;
			}
			*/
		}
	}
}
