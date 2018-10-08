using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//移動クラス
	private MovingAnimation _Move;
	//移動可能か判定
	private MapManager _MapManager;
	//メッセージマネージャ
	private MessageManager _MessageMan;

	public void SetUp()
	{
		_MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

		//ワールド座標の開始位置をマップデータに入力する
		int x = _MapManager.ToGridX( transform.position );
		int y = _MapManager.ToGridY( transform.position );

		_MapManager.SetData( x, y, MapElement.PLAYER );

		//マップデータからワールド座標を決める
		transform.position = _MapManager.ToWorldPosition( x, y );

		_Move = GetComponent<MovingAnimation>();
		_Move.SetUp();

		_MessageMan = GameObject.Find("MessageManager").GetComponent<MessageManager>();
	}

	public void Move()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			transform.rotation = Quaternion.Euler( 0, 0, 0 );
			if( _MapManager.CanMove( transform.position, eDir.UP )){
				_Move.StartAnime( MapElement.PLAYER, Vector3.forward );
				_MessageMan.AddMessage("上に動きました");
			}
		}
		else if( Input.GetKeyDown( KeyCode.DownArrow ) ){
			transform.rotation = Quaternion.Euler( 0, 180, 0 );
			if( _MapManager.CanMove( transform.position, eDir.DOWN )){
				_Move.StartAnime( MapElement.PLAYER, Vector3.back );
				_MessageMan.AddMessage("下に動きました");
			}
		}
		else if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
			transform.rotation = Quaternion.Euler( 0, 270, 0 );
			if( _MapManager.CanMove( transform.position, eDir.LEFT )){
				_Move.StartAnime( MapElement.PLAYER, Vector3.left );
				_MessageMan.AddMessage("左に動きました");
			}
		}
		else if( Input.GetKeyDown( KeyCode.RightArrow ) ){
			transform.rotation = Quaternion.Euler( 0, 90, 0 );
			if( _MapManager.CanMove( transform.position, eDir.RIGHT )){
				_Move.StartAnime( MapElement.PLAYER, Vector3.right );
				_MessageMan.AddMessage("右に動きました");
			}
		}
		else{
			//Do Nothing
		}
	}
}
