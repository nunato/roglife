using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
	private eAct _ActorStetas;

	public eAct ActorState
	{
		set{ _ActorStetas = value;}
		get{ return _ActorStetas;}
	}

	void Start()
	{
		_ActorStetas = eAct.KEY_INPUT;
	}
}
