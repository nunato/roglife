using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
	public event Action _ActionUpArrow;
	public event Action _ActionDownArrow;
	public event Action _ActionLeftArrow;
	public event Action _ActionRightArrow;

	public event Action _ActionMKey;

	public event Action _ActionSKey;
	public event Action _ActionLKey;

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			_ActionUpArrow();
		}
		else if( Input.GetKeyDown( KeyCode.DownArrow ) ){
			_ActionDownArrow();
		}
		else if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
			_ActionLeftArrow();
		}
		else if( Input.GetKeyDown( KeyCode.RightArrow ) ){
			_ActionRightArrow();
		}
		else if( Input.GetKeyDown( KeyCode.M ) ){
			_ActionMKey();
		}
		else if( Input.GetKeyDown( KeyCode.S ) ){
			_ActionSKey();
		}
		else if( Input.GetKeyDown( KeyCode.L ) ){
			_ActionLKey();
		}
	}
}
