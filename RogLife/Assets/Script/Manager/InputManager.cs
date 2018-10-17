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

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			_ActionUpArrow();
		}
		if( Input.GetKeyDown( KeyCode.DownArrow ) ){
			_ActionDownArrow();
		}
		if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
			_ActionLeftArrow();
		}
		if( Input.GetKeyDown( KeyCode.RightArrow ) ){
			_ActionRightArrow();
		}
	}
}
