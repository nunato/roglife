using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//移動クラス
	private Movement _Move;
	//移動可能か判定
	private MapManager _MapManager;

	public void SetUp()
	{
		_MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

		//ワールド座標の開始位置をマップデータに入力する
		int x = _MapManager.ToGridX( transform.position );
		int y = _MapManager.ToGridY( transform.position );

		_MapManager.SetData( x, y, MapElement.ENEMY );

		//マップデータからワールド座標を決める
		transform.position = _MapManager.ToWorldPosition( x, y );

		_Move = GetComponent<Movement>();
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			if( _MapManager.CanMove( transform.position, eDir.UP )){
				_Move.Move( MapElement.ENEMY, Vector3.forward );
				transform.rotation = Quaternion.Euler( 0, 0, 0 );
			}
		}
		else if( Input.GetKeyDown( KeyCode.DownArrow ) ){
			if( _MapManager.CanMove( transform.position, eDir.DOWN )){
				_Move.Move( MapElement.ENEMY, Vector3.back );
				transform.rotation = Quaternion.Euler( 0, 180, 0 );
			}
		}
		else if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
			if( _MapManager.CanMove( transform.position, eDir.LEFT )){
				_Move.Move( MapElement.ENEMY, Vector3.left );
				transform.rotation = Quaternion.Euler( 0, 270, 0 );
			}
		}
		else if( Input.GetKeyDown( KeyCode.RightArrow ) ){
			if( _MapManager.CanMove( transform.position, eDir.RIGHT )){
				_Move.Move( MapElement.ENEMY, Vector3.right );
				transform.rotation = Quaternion.Euler( 0, 90, 0 );
			}
		}
		else{
			//Do Nothing
		}
	}
}
