﻿using System.Collections;
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

	void Start()
	{
		_TMXLoader.CreateMapData();

		CreateMapWall();
	}

	//MapDataから壁を読み込みキューブを生成する
	private void CreateMapWall()
	{
		int height = _TMXLoader.LayerHeight;
		int Width = _TMXLoader.LayerWidth;
		for( int h = 0; h < height; h++ ){
			for( int w = 0; w < Width; w++ ){
				//壁の生成
				if( _TMXLoader.GetLayerValue( w, h ) == 2 ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.position = new Vector3( w, 0, h );
					cube.GetComponent<Renderer>().material = _WallMaterial;
				}
				//床の生成
				else if( _TMXLoader.GetLayerValue( w, h ) == 1 ){
					GameObject cube = GameObject.CreatePrimitive( PrimitiveType.Cube );
					cube.transform.position = new Vector3( w, -1, h );
					cube.GetComponent<Renderer>().material = _FloorMaterial;
				}
			}
		}
	}
}