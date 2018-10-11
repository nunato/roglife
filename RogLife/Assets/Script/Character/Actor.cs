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

	public void SetUp()
	{
		_ActorStetas = eAct.KEY_INPUT;

		_Param = GetComponent<CharacterParam>();
	}

	public void SetCharacterParam( CharacterParam param )
	{
		_Param = param;
		_Param.Dump();
	}
}
