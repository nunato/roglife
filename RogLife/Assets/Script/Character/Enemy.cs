using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /* キャラクターの初期位置 後で複数の地点からスポーンするようにする */
	[SerializeField]
	private GameObject StartPosition;
	//移動クラス
	[SerializeField]private Movement PlayerMove;
	//移動可能か判定
	[SerializeField]
	private MapManager _MapMng;

	void Start()
	{
		transform.position = StartPosition.transform.position;
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			if( _MapMng.CanMove( transform.position, eDir.UP )){
				PlayerMove.Move( Vector3.forward );
				transform.rotation = Quaternion.Euler( 0, 0, 0 );
			}
		}
		else if( Input.GetKeyDown( KeyCode.DownArrow ) ){
			if( _MapMng.CanMove( transform.position, eDir.DOWN )){
				PlayerMove.Move( Vector3.back );
				transform.rotation = Quaternion.Euler( 0, 180, 0 );
			}
		}
		else if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
			if( _MapMng.CanMove( transform.position, eDir.LEFT )){
				PlayerMove.Move( Vector3.left );
				transform.rotation = Quaternion.Euler( 0, 270, 0 );
			}
		}
		else if( Input.GetKeyDown( KeyCode.RightArrow ) ){
			if( _MapMng.CanMove( transform.position, eDir.RIGHT )){
				PlayerMove.Move( Vector3.right );
				transform.rotation = Quaternion.Euler( 0, 90, 0 );
			}
		}
		else{
			//Do Nothing
		}
	}
}
