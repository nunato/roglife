using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
	// キャラクター状態
	private eAct _ActorStetas;
	// キャラクターパラメータ
	private CharacterParam _Param;
	// マップデータ
	private MapManager _MapManager;
	// メッセージマネージャ
	private MessageManager _MessageMan;
	// 攻撃処理
	private AttackAnimation _Attack;
	//
	private GameManager _GameManager;

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

	public void SetUp( eMapElement eElement )
	{
		_ActorStetas = eAct.KEY_INPUT;
		_MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

		// ワールド座標の開始位置をマップデータに入力する
		int x = _MapManager.ToGridX( transform.position );
		int y = _MapManager.ToGridY( transform.position );

		_MapManager.SetData( x, y, eElement );

		// マップデータからワールド座標を決める
		transform.position = _MapManager.ToWorldPosition( x, y );

		_MessageMan = GameObject.Find("MessageManager").GetComponent<MessageManager>();

		_Attack = GetComponent<AttackAnimation>();
		_Attack.SetUp();

		_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public bool CanMove( Vector3 position, eDir dir )
	{
		return _MapManager.CanMove( transform.position, dir );
	}

	public bool CanAttack( Vector3 position, eDir dir )
	{
		return _MapManager.CanAttack( transform.position, dir );
	}

	public void AddMessage( string message )
	{
		_MessageMan.AddMessage( message );
	}

	public void DeleteOldGridPosition()
	{
		int x = _MapManager.ToGridX( transform.position );
		int y = _MapManager.ToGridY( transform.position );
		_MapManager.DeleteData( x, y );
	}

	public Vector2 GetMapPosition()
	{
		Vector2 MapPos = _MapManager.ToGridVector2( transform.position );
		return MapPos;
	}

	public void StartAttack( eDir dir )
	{
		// 方向から対象Idを取得する
		Vector2 targetPos = _MapManager.GetGridPosFromDir( transform.position, dir );
		int? targetId = _GameManager.GetCharacterId( targetPos );
		if( targetId == null ){
			Debug.Log("ERROR targetId");
			return;
		}

		// IDからパラメータを取得する
		CharacterParam? targetParam = _GameManager.GetCharacterParamFromId( (int)targetId );
		if( targetParam == null ){
			Debug.Log("ERROR targetParam");
			return;
		}
	
		// 自身のパラメータと対象のパラメータからダメージを計算する
		int damage = CalculationDamage( _Param, (CharacterParam)targetParam );

		// アニメーションさせる
		_Attack.StartAnimation();

		// ダメージの表示をする
		_MessageMan.AddMessage( "プレイヤー" + " は " + "スライム" + " に " + damage + " のダメージを与えた ");
	}

	// ダメージ計算
	// 暫定で攻撃側の攻撃力をダメージにする
	private int CalculationDamage( CharacterParam sorceParam, CharacterParam targetParam )
	{
		return sorceParam._Str;
	}

}
