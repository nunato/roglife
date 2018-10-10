using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParam : MonoBehaviour
{
	private int _ID;	// ユニークID
	private int _Level;	// レベル
	private int _HP;	// HP
	private int _HPMax;	// 最大HP
	private int _Str;	// 力
	private int _Exp;	// 獲得経験値
	[SerializeField]
	private int _XP;	// 倒したときの経験値

	public void SetCharacterID( int id )
	{
		_ID = id;
	}

	public int Level
	{
		set{ _Level = value;}
		get{ return _Level;}
	}

	public int HP
	{
		set{ _HP = value;}
		get{ return _HP;}
	}

	public int HPMax
	{
		set{ _HPMax = value;}
		get{ return _HPMax;}
	}

	public int Str
	{
		set{ _Str = value;}
		get{ return _Str;}
	}

	public int Exp
	{
		set{ _Exp = value;}
		get{ return _Exp;}
	}

	public void Dump()
	{
		Debug.Log( "ID " + _ID );
		Debug.Log( "Level " + _Level );
		Debug.Log( "HP " + _HP );
		Debug.Log( "HPMax " + _HPMax );
		Debug.Log( "Str " + _Str );
		Debug.Log( "Exp " + _Exp );
	}
}
