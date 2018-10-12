using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* このクラスはJsonUtilityを使うためにプロパティをpublicで宣言する */
[Serializable]
public struct SaveData
{
	/* プレイヤーの位置情報 */
	public Vector3 _PlayerPos;
	/*キャラクターデータ */
	public CharacterParam _Param;
	/* マップ情報 */
	public Layer2D _MapData;

	public void Dump()
	{
		Debug.Log( _PlayerPos );
		Debug.Log( "--------------" );
		Debug.Log( _Param );
		Debug.Log( "--------------" );
		Debug.Log( _MapData );
	}
}
