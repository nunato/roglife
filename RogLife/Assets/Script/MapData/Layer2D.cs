using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer2D
{
	private int _width = 0;
	private int _height = 0;

	private int[] _vals = null;

	public int Width
	{
		get{ return _width;}
		set{ _width = value;}
	}

	public int Height
	{
		get{ return _height;}
		set{ _height = value;}
	}

	public int[] Value
	{
		get{ return _vals;}
		set{ _vals = value;}
	}

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

