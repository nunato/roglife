using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ゲームの状態をあらわす定義 */
public enum eSequence
{
	SETUP,		// ゲーム起動時の初期化
	KEY_INPUT,	// キー入力待ち

	// 移動
	PLAYER_MOVE_BEGIN,
	PLAYER_MOVE,
	PLAYER_MOVE_END,

	ENEMY_MOVE_BEGIN,
	ENEMY_MOVE,
	ENEMY_MOVE_END,

	//行動
	ACT_BEGIN,
	ACT,
	ACT_END,

	TURN_END,	// ターン終了
}
