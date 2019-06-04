using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// 移動クラス
	private MovingAnimation _Move;
	// キャラクター共通処理
	private Actor _Actor;

	private GameManager _GameManager;

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

		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void Move( eDir dir )
	{
		// 向きの変更。移動できない場合も方向は変更する
		SetRotation( dir );
		// 移動の判定
		if( CanMoveAction( dir ) ){
			// 移動の開始に遷移
			_GameManager.GameSequence = eSequence.ENEMY_MOVE_BEGIN;
			// 古い座標を削除する
			_Actor.DeleteOldGridPosition();
			// 移動アニメーションを開始する
			_Move.StartAnime( dir );
			_GameManager.GameSequence = eSequence.ENEMY_MOVE;
		}
	}

	private void SetRotation( eDir dir )
	{
		switch( dir ){
			case eDir.UP:
				transform.rotation = Quaternion.Euler( 0, 0, 0 );
				return;
			case eDir.DOWN:
				transform.rotation = Quaternion.Euler( 0, 180, 0 );
				return;
			case eDir.LEFT:
				transform.rotation = Quaternion.Euler( 0, 270, 0 );
				return;
			case eDir.RIGHT:
				transform.rotation = Quaternion.Euler( 0, 90, 0 );
				return;
			default:
				Debug.Log("ERROR SetRotation");
				return;
		}
	}

	private bool CanMoveAction( eDir dir )
	{
		if( _Actor.CanMove( transform.position, dir )){
			return true;
		}
		return false;
	}

	void Update()
	{
		// 移動状態のときpositionを更新する
		if( _GameManager.GameSequence == eSequence.ENEMY_MOVE ){
			bool IsMove =　_Move.UpdatePosition();
			// 敵の移動終わったら移動完了
			if( IsMove == false ){
				_GameManager.GameSequence = eSequence.MOVE_END;
			}
		}
	}

}
