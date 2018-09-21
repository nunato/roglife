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

	private Layer2D _layer;

	public int Width
	{
		get{ return _layer.Width;}
		set{ _layer.Width = value;}
	}

	public int Height
	{
		get{ return _layer.Height;}
		set{ _layer.Height = value;}
	}

	public int[] Value
	{
		get{ return _layer.Value;}
		set{ _layer.Value = value;}
	}

	//移動先が移動できるマスであるか判定する
	public bool CanMove( Vector3 CurrentPos, eDir dir )
	{
		//ワールド座標からグリッド座標に無理やり変更しているので何か考える
		int x = (int)CurrentPos.x;
		int y = (int)CurrentPos.z;

		switch( dir ){
			case eDir.LEFT:
				x--;
				break;
			case eDir.UP:
				y++;
				break;
			case eDir.RIGHT:
				x++;
				break;
			case eDir.DOWN:
				y--;
				break;
		}
		int Panel = _layer.Get( x, y );

		if( Panel != (int)MapElement.FLOOR ){
			return false;
		}
		else{
			return true;
		}
	}

	//マップデータにデータを追加する
	public void SetData( int x, int y, MapElement element )
	{
		_layer.Set( x, y, (int)element );
	}

	public void DeleteData( int x, int y )
	{
		_layer.Set( x, y, (int)MapElement.FLOOR );
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

	void Awake()
	{
		_layer = _TMXLoader.CreateMapData();

		CreateMapWall();
	}

	//MapDataから壁を読み込みキューブを生成する
	private void CreateMapWall()
	{
		int height = _layer.Height;
		int Width = _layer.Width;
		for( int h = 0; h < height; h++ ){
			for( int w = 0; w < Width; w++ ){
				//壁の生成
				int Panel = _layer.Get( w, h );
				if( Panel == (int)MapElement.WALL ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.position = new Vector3( w, 0, h );
					cube.GetComponent<Renderer>().material = _WallMaterial;
				}
				//床の生成
				else if( Panel == (int)MapElement.FLOOR ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.position = new Vector3( w, -1, h );
					cube.GetComponent<Renderer>().material = _FloorMaterial;
				}
			}
		}
	}
}
