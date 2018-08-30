﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	//マス移動にかかる時間
	[SerializeField]private float MoveDuration;
	//移動前の位置
	private Vector3 StartPos;
	//移動後の位置
	private Vector3 EndPos;
	//経過時間
	private float ElapsedTime = 0;
	//移動中かの判定
	private bool IsMoving;

	public void Move( Vector3 moveAt )
	{
		if( IsMoving != true ){
			MoveStart( moveAt );
		}
	}

	private void MoveStart( Vector3 targetPos )
	{
		StartPos = transform.position;
		EndPos = transform.position + targetPos;
		ElapsedTime = 0;
		IsMoving = true;
	}

	void Start()
	{
		EndPos = transform.position;
		IsMoving = false;
	}

	void Update()
	{
		if( IsMoving == true ){
			if( transform.position != EndPos ){
				ElapsedTime += Time.deltaTime;
				float rate = ElapsedTime / MoveDuration;
				//rateを0~1の範囲に収める
				rate = Mathf.Clamp(rate, 0f, 1f);
				//Lerp：StartPosを0,EndPosを1としたときに、rate(0~１)の位置を返してくれる
				transform.position = Vector3.Lerp(StartPos, EndPos, rate);
			}
			else{
				IsMoving = false;
			}
		}
	}
}
