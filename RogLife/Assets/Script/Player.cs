using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//移動クラス
	[SerializeField]private Movement PlayerMove;

	void Update()
	{
		PlayerMove.Move();
	}
}
