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

	void Start()
	{
		transform.position = StartPosition.transform.position;
	}

	void Update()
	{
		/* 現在地点と移動方向を元に移動できるか判定する */
		PlayerMove.Move();
	}
}
