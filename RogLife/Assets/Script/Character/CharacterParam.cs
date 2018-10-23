using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CharacterParam
{
	public int _ID;	// ユニークID
	// キャラクタータイプ用のIDを用意する
	public int _Level;	// レベル
	public int _HP;	// HP
	public int _HPMax;	// 最大HP
	public int _Str;	// 力
	public int _Exp;	// 獲得経験値
	public int _XP;	// 倒したときの経験値

	public void Dump()
	{
		Debug.Log( "ID " + _ID );
		Debug.Log( "Level " + _Level );
		Debug.Log( "HP " + _HP );
		Debug.Log( "HPMax " + _HPMax );
		Debug.Log( "Str " + _Str );
		Debug.Log( "Exp " + _Exp );
		Debug.Log( "XP " + _XP );
	}
}
