using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//プレイヤーの初期位置
	[SerializeField]
	private GameObject StartPosition;
	//移動クラス
	[SerializeField]private Movement PlayerMove;
	//キャラクターの向き
	private Vector3 _LockAt = Vector3.zero;
	//移動可能か判定
	[SerializeField]
	private MapManager _MapMng;
	//メッセージマネージャ
	[SerializeField]private MessageManager MessageMan;

	public Vector3 LockAt
	{
		get{ return _LockAt; }
		set{ _LockAt = value;}
	}

	void Start()
	{
		//ワールド座標の開始位置をマップデータに入力する
		int x = _MapMng.ToGridX( StartPosition.transform.position );
		int y = _MapMng.ToGridY( StartPosition.transform.position );

		_MapMng.SetData( x, y, MapElement.PLAYER );

		//マップデータからワールド座標を決める
		transform.position = _MapMng.ToWorldPosition( x, y );
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			LockAt = Vector3.forward;
			transform.rotation = Quaternion.Euler( 0, 0, 0 );
			if( _MapMng.CanMove( transform.position, eDir.UP )){
				PlayerMove.Move( MapElement.PLAYER, LockAt );
				MessageMan.AddMessage("上に動きました");
			}
		}
		else if( Input.GetKeyDown( KeyCode.DownArrow ) ){
			LockAt = Vector3.back;
			transform.rotation = Quaternion.Euler( 0, 180, 0 );
			if( _MapMng.CanMove( transform.position, eDir.DOWN )){
				PlayerMove.Move( MapElement.PLAYER, LockAt );
				MessageMan.AddMessage("下に動きました");
			}
		}
		else if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
			LockAt = Vector3.left;
			transform.rotation = Quaternion.Euler( 0, 270, 0 );
			if( _MapMng.CanMove( transform.position, eDir.LEFT )){
				PlayerMove.Move( MapElement.PLAYER, LockAt );
				MessageMan.AddMessage("左に動きました");
			}
		}
		else if( Input.GetKeyDown( KeyCode.RightArrow ) ){
			LockAt = Vector3.right;
			transform.rotation = Quaternion.Euler( 0, 90, 0 );
			if( _MapMng.CanMove( transform.position, eDir.RIGHT )){
				PlayerMove.Move( MapElement.PLAYER, LockAt );
				MessageMan.AddMessage("右に動きました");
			}
		}
		else{
			//Do Nothing
		}
	}
}
