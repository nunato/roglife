using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
	private GameManager _GameManager;
	
	public void SetUp()
	{
		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void StartAnimation()
	{
		Debug.Log( "ここはまだ呼ばれない" );
	//	_GameManager.GameSequence = eSequence.KEY_INPUT;
	}
}
