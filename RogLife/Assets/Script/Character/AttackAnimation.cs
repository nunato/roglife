using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
	private Actor _Actor;
	
	public void SetUp()
	{
		_Actor = GetComponent<Actor>();
	}

	public void StartAnimation()
	{
		_Actor.ActorState = eAct.KEY_INPUT;
	}
}
