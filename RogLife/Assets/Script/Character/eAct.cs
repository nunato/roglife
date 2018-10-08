using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* キャラクターの行動状態をあらわす定義 */
public enum eAct
{
	KEY_INPUT,	//キー入力待ち

	//アクション
	ACT_BEGIN,
	ACT,
	ACT_END,

	//移動
	MOVE_BEGIN,
	MOVE,
	MOVE_END,

	TURN_END,	//ターン終了
}
