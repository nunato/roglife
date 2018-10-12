using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
	private eAct _ActorStetas;
	//キャラクターパラメータ
	private CharacterParam _Param;

	public eAct ActorState
	{
		set{ _ActorStetas = value;}
		get{ return _ActorStetas;}
	}

	public CharacterParam Param
	{
		set{ _Param = value;}
		get{ return _Param;}
	}

	public void SetUp()
	{
		_ActorStetas = eAct.KEY_INPUT;
	}
}
