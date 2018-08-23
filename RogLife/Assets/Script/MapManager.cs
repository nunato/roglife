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

	public bool CanMove( Vector3 CurrentPos, eDir dir )
	{
		return false;
	}

	void Start()
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
				if( _layer.Get( w, h ) == 2 ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.position = new Vector3( w, 0, h );
					cube.GetComponent<Renderer>().material = _WallMaterial;
				}
				//床の生成
				else if( _layer.Get( w, h ) == 1 ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.position = new Vector3( w, -1, h );
					cube.GetComponent<Renderer>().material = _FloorMaterial;
				}
			}
		}
	}
}
