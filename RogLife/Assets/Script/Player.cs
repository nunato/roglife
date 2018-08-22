using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//移動クラス
	[SerializeField]private Movement PlayerMove;

	void Update()
	{
		/* 現在地点と移動方向を元に移動できるか判定する */
		PlayerMove.Move();
	}
}
