using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveData
{
	/* プレイヤーの位置情報 */
	public Vector3 _PlayerPos;
	/* プレイヤーの向き */
	public Vector3 _LockAt;
	/* マップ情報 */
	public int _width;
	public int _height;

	public int[] _vals;

	public void Dump()
	{
		Debug.Log( _PlayerPos );
		Debug.Log( _LockAt );
		Debug.Log( _width );
		Debug.Log( _height );
		Debug.Log( _vals );
	}
}
