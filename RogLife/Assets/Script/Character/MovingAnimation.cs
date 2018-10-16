using System.Collections;
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
	//状態変数
	private Actor _Actor;

	public void SetUp()
	{
		EndPos = transform.position;
		_Actor = GetComponent<Actor>();
	}

	public void StartAnime( Vector3 targetPos )
	{
		if( _Actor.ActorState == eAct.MOVE_BEGIN ){
			StartPos = transform.position;
			EndPos = transform.position + targetPos;
			ElapsedTime = 0;
			_Actor.ActorState = eAct.MOVE;
		}
	}

	void FixedUpdate()
	{
		if( _Actor.ActorState == eAct.MOVE ){
			if( transform.position != EndPos ){
				ElapsedTime += Time.deltaTime;
				float rate = ElapsedTime / MoveDuration;
				//rateを0~1の範囲に収める
				rate = Mathf.Clamp(rate, 0f, 1f);
				//Lerp：StartPosを0,EndPosを1としたときに、rate(0~１)の位置を返してくれる
				transform.position = Vector3.Lerp(StartPos, EndPos, rate);
			}
			else{
				_Actor.ActorState = eAct.MOVE_END;
			}
		}
	}
}
