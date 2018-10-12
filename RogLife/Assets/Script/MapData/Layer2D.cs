using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Layer2D
{
	public int _width;
	public int _height;

	public int[] _vals;

	public void Create( int width, int height )
	{
		this._width = width;
		this._height = height;
		_vals = new int[ width * height ];
	}

	public int Get( int x, int y )
	{
		if( x < 0 || x >= _width ){
			return -1;
		}
		if( y < 0 || y >= _height ){
			return -1;
		}
		return _vals[ y * _width + x ];
	}

	public void Set( int x, int y, int val )
	{
		if( x < 0 || x >= _width ){
			return;
		}
		if( y < 0 || y >= _height ){
			return;
		}
		_vals[ y * _width + x ] = val;
	}
}

