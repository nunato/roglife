using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	//メッセージマネージャ
	[SerializeField]private MessageManager MessageMan;
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
	private Vector3 LockAt = Vector3.zero;

	public Vector3 PlayerLockAt
	{
		get{ return LockAt; }
	}

	public void Move()
	{
		if( IsMoving != true ){
			if( Input.GetKeyDown( KeyCode.UpArrow ) ){
				LockAt = Vector3.forward;
				MoveStart( Vector3.forward );
				MessageMan.AddMessage("上に動きました");
			}
			else if( Input.GetKeyDown( KeyCode.DownArrow ) ){
				LockAt = Vector3.back;
				MoveStart( Vector3.back );
				MessageMan.AddMessage("下に動きました");
			}
			else if( Input.GetKeyDown( KeyCode.LeftArrow ) ){
				LockAt = Vector3.left;
				MoveStart( Vector3.left );
				MessageMan.AddMessage("左に動きました");
			}
			else if( Input.GetKeyDown( KeyCode.RightArrow ) ){
				LockAt = Vector3.right;
				MoveStart( Vector3.right );
				MessageMan.AddMessage("右に動きました");
			}
			else{
				//Do Nothing
			}
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
