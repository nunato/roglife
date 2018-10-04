using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveData
{
	/* プレイヤーの位置情報 */
	public Vector3 _PlayerPos;
	/* マップ情報 */
	/* 横サイズ */
	public int _width;
	/* 縦サイズ */
	public int _height;
	/* マップデータ */
	public int[] _vals;

	public void Dump()
	{
		Debug.Log( _PlayerPos );
		Debug.Log( _width );
		Debug.Log( _height );
		Debug.Log( _vals );
	}
}
