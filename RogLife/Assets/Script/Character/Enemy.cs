using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//移動クラス
	private MovingAnimation _Move;
	//キャラクター共通処理
	private Actor _Actor;

	public void SetUp()
	{
		_Move = GetComponent<MovingAnimation>();
		if( _Move != null ){
			_Move.SetUp();
		}

		_Actor = GetComponent<Actor>();
		if( _Actor != null ){
			_Actor.SetUp( eMapElement.ENEMY );
		}
	}
}
