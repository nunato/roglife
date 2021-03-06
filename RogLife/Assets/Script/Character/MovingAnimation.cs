﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnimation : MonoBehaviour
{
	//マス移動にかかる時間
	[SerializeField]
	private float MoveDuration;
	//移動前の位置
	private Vector3 StartPos;
	//移動後の位置
	private Vector3 EndPos;
	//経過時間
	private float ElapsedTime = 0;

	private MapManager _MapManager;

	public void SetUp()
	{
		_MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
		EndPos = transform.position;
	}

	public void StartAnime( eDir dir )
	{
		Vector3 targetPos = ConvertActionToTargetPosition( dir );

		StartPos = transform.position;
		EndPos = transform.position + targetPos;
		ElapsedTime = 0;
	}

	private Vector3 ConvertActionToTargetPosition( eDir dir )
	{
		switch( dir ){
			case eDir.UP:
				return Vector3.forward;
			case eDir.DOWN:
				return Vector3.back;
			case eDir.LEFT:
				return Vector3.left;
			case eDir.RIGHT:
				return Vector3.right;
			default:
				return Vector3.zero;
		}
	}

	// Moveの間この関数を呼び続ける
	public bool UpdatePosition( eMapElement element )
	{
		if( transform.position != EndPos ){
			ElapsedTime += Time.deltaTime;
			float rate = ElapsedTime / MoveDuration;
			//rateを0~1の範囲に収める
			rate = Mathf.Clamp(rate, 0f, 1f);
			//Lerp：StartPosを0,EndPosを1としたときに、rate(0~１)の位置を返してくれる
			transform.position = Vector3.Lerp(StartPos, EndPos, rate);
			return true;
		}
		else{
			//移動後のグリッド座標の更新
			int x = _MapManager.ToGridX( transform.position );
			int y = _MapManager.ToGridY( transform.position );
			_MapManager.SetData( x, y, element );
			return false;
		}
	}
}
