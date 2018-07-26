using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class TMXLoader : MonoBehaviour
{
	public class Layer2D
	{
		private int _width = 0;
		private int _height = 0;

		private int[] _vals = null;

		public int Width
		{
			get{ return _width;}
		}

		public int Height
		{
			get{ return _height;}
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

		public void Dump()
		{
			print("[Layer2D](w,h)=(" + _width + "," + _height + ")");
			for( int y = 0; y < _height; y++ ){
				string s = "";
				for( int x = 0; x < _width; x++ ){
					s += Get( x, y ) + ",";
				}
				print(s);
			}
		}
	}

	private Layer2D _layer;

	public int GetLayerWidth()
	{
		return _layer.Width;
	}

	public int GetLayerHeight()
	{
		return _layer.Height;
	}

	public int GetLayerValue( int w, int h )
	{
		return _layer.Get( w, h );
	}

	public void CreateMapData()
	{
		//レイヤー生成
		_layer = new Layer2D();
		//リソースを取得
		TextAsset tmx = Resources.Load("untitled") as TextAsset;

		//Xmlに変換
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(tmx.text);
		//Xmlから要素を取得
		XmlNodeList mapList = xmlDoc.GetElementsByTagName("map");
		foreach( XmlNode map in mapList ){
			XmlNodeList childList = map.ChildNodes;
			foreach( XmlNode child in childList ){
				if( child.Name != "layer" ){
					continue;
				}

				//属性の取得
				XmlAttributeCollection attrs = child.Attributes;
				//dataを格納する配列の初期化
				int w = int.Parse( attrs.GetNamedItem("width").Value );
				int h = int.Parse( attrs.GetNamedItem("height").Value );
				_layer.Create( w, h );

				//dataノードの取得
				XmlNode node = child.FirstChild;
				XmlNode n = node.FirstChild;
				string val = n.Value;
				//先頭の改行を削除
				val = val.TrimStart();

				//csvの解析
				int y = 0;
				foreach( string line in val.Split('\n') ){
					int x = 0;
					foreach( string s in line.Split(',') ){
						int v = 0;
						if( int.TryParse( s, out v ) == false ){
							continue;
						}
						
						_layer.Set( x, y, v );
						x++;
					}
					y++;
				}
			}
		}

		//デバッグログ
		//layer.Dump();
	}
}
