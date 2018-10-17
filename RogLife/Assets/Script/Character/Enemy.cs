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
		_Move.SetUp();

		_Actor = GetComponent<Actor>();
		_Actor.SetUp( eMapElement.ENEMY );
	}
}
