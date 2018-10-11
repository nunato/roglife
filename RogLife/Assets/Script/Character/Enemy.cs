using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//移動クラス
	private MovingAnimation _Move;
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

		_Move = GetComponent<MovingAnimation>();
		_Move.SetUp();
	}
}
