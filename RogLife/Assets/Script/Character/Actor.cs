using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
	//キャラクター状態
	private eAct _ActorStetas;
	//キャラクターパラメータ
	private CharacterParam _Param;
	//マップデータ
	private MapManager _MapManager;
	//メッセージマネージャ
	private MessageManager _MessageMan;

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

		//ワールド座標の開始位置をマップデータに入力する
		int x = _MapManager.ToGridX( transform.position );
		int y = _MapManager.ToGridY( transform.position );

		_MapManager.SetData( x, y, eElement );

		//マップデータからワールド座標を決める
		transform.position = _MapManager.ToWorldPosition( x, y );

		_MessageMan = GameObject.Find("MessageManager").GetComponent<MessageManager>();
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

}
