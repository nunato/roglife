using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
	[SerializeField]
	private TMXLoader _TMXLoader;
	[SerializeField]
	private Material _WallMaterial;
	[SerializeField]
	private Material _FloorMaterial;
	[SerializeField]
	private GameObject _StairsPrefab;
	private GameObject _StairsInstance;

	private Layer2D _layer;

	public Layer2D MapData
	{
		get{ return _layer;}
		set{ _layer = value;}
	}

	public bool IsStair( Vector3 CurrentPos, eDir dir )
	{
		int Panel = getNextPanel( CurrentPos, dir );
		if( Panel == (int)eMapElement.STAIRS ){
			return true;
		}
		else{
			return false;
		}
	}

	// 移動先が移動できるマスか判定する
	public bool CanMove( Vector3 CurrentPos, eDir dir )
	{
		int Panel = getNextPanel( CurrentPos, dir );

		if( Panel == (int)eMapElement.WALL ){
			return false;
		}
		else{
			return true;
		}
	}

	// 移動先が敵キャラクターか判定する
	public bool CanAttack( Vector3 CurrentPos, eDir dir )
	{
		int Panel = getNextPanel( CurrentPos, dir );

		if( Panel != (int)eMapElement.ENEMY ){
			return false;
		}
		else{
			return true;
		}
	}

	private int getNextPanel( Vector3 CurrentPos, eDir dir )
	{
		Vector2 GridPos = GetGridPosFromDir( CurrentPos, dir );
		return _layer.Get( (int)GridPos.x, (int)GridPos.y );
	}

	// 現在地点から指定方向の座標を取得する
	public Vector2 GetGridPosFromDir( Vector3 CurrentPos, eDir dir )
	{
		Vector2 GridPos = new Vector2( ToGridX( CurrentPos ), ToGridY( CurrentPos ) );

		switch( dir ){
			case eDir.LEFT:
				GridPos.x--;
				break;
			case eDir.UP:
				GridPos.y++;
				break;
			case eDir.RIGHT:
				GridPos.x++;
				break;
			case eDir.DOWN:
				GridPos.y--;
				break;
		}
		return GridPos;
	}

	// マップデータにデータを追加する
	public void SetData( int x, int y, eMapElement element )
	{
		_layer.Set( x, y, (int)element );
	}

	// マップデータのデータを床にする
	public void DeleteData( int x, int y )
	{
		_layer.Set( x, y, (int)eMapElement.FLOOR );
	}

	// グリッド座標をワールド座標に変換
	public Vector3 ToWorldPosition( int x, int y )
	{
		Vector3 pos = new Vector3( x, 0, y );
		return pos;
	}

	// ワールド座標(X)をグリッド座標(X)に変換
	public int ToGridX( Vector3 pos )
	{
		int x;
		x = (int)pos.x;
		return x;
	}
	// ワールド座標(Z)をグリッド座標(Y)に変換
	public int ToGridY( Vector3 pos )
	{
		int y;
		//ワールド座標はzがグリッドのyなので注意
		y = (int)pos.z;
		return y;
	}
	// ワールド座標をグリッド座標に変換
	public Vector2 ToGridVector2( Vector3 pos )
	{
		Vector2 GridVector2Pos = new Vector2( ToGridX( pos ), ToGridY( pos ) );
		return GridVector2Pos;
	}

	public void SetUp()
	{
		_layer = _TMXLoader.CreateMapData();

		CreateMapWall();
	}

	//MapDataから壁を読み込みキューブを生成する
	private void CreateMapWall()
	{
		int height = _layer._height;
		int Width = _layer._width;
		for( int h = 0; h < height; h++ ){
			for( int w = 0; w < Width; w++ ){
				// 壁の生成
				int Panel = _layer.Get( w, h );
				if( Panel == (int)eMapElement.WALL ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.parent = transform;
					cube.transform.position = new Vector3( w, 0, h );
					cube.GetComponent<Renderer>().material = _WallMaterial;
				}
				// 床の生成
				else if( Panel == (int)eMapElement.FLOOR ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.parent = transform;
					cube.transform.position = new Vector3( w, -1, h );
					cube.GetComponent<Renderer>().material = _FloorMaterial;
				}
				// 階段の生成
				else if( Panel == (int)eMapElement.STAIRS ){
					Vector3 stairPosition = new Vector3( w, 0, h );
					Instantiate( _StairsPrefab, stairPosition, Quaternion.identity );
				}
			}
		}
	}
}
