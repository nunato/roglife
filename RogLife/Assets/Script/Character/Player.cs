using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// 移動クラス
	private MovingAnimation _Move;
	// キャラクター共通処理
	private Actor _Actor;

	private GameManager _GameManager;

	// 初期化メソッド
	public void SetUp()
	{
		_Move = GetComponent<MovingAnimation>();
		_Move.SetUp();

		_Actor = GetComponent<Actor>();
		_Actor.SetUp( eMapElement.PLAYER );

		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// 移動メソッド
	public void Move( eDir dir )
	{
		// 向きの変更。移動できない場合も方向は変更する
		SetRotation( dir );
		// 移動の判定
		if( CanMoveAction( dir ) ){
			// 移動の開始に遷移
			_GameManager.GameSequence = eSequence.PLAYER_MOVE_BEGIN;
			// 古い座標を削除する
			_Actor.DeleteOldGridPosition();
			// 移動アニメーションを開始する
			_Move.StartAnime( dir );
			_Actor.AddMessage( dir + " に動きました");
			_GameManager.GameSequence = eSequence.PLAYER_MOVE;
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

	// 攻撃メソッド
	public void Attack( eDir dir )
	{
		if( _GameManager.GameSequence == eSequence.KEY_INPUT ){
			if( CanAttackAction( dir ) ){
				_GameManager.GameSequence = eSequence.ACT_BEGIN;
				_Actor.StartAttack( dir );
			}
		}
	}

	private bool CanAttackAction( eDir dir )
	{
		if( _Actor.CanAttack( transform.position, dir )){
			return true;
		}
		return false;
	}

	void Update()
	{
		// 移動状態のときpositionを更新する
		if( _GameManager.GameSequence == eSequence.PLAYER_MOVE ){
			bool IsMove =　_Move.UpdatePosition();
			// 移動終わったら敵に移る
			if( IsMove == false ){
				_GameManager.GameSequence = eSequence.PLAYER_MOVE_END;
			}
		}
	}
}
