﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class TMXLoader : MonoBehaviour
{
	public Layer2D CreateMapData()
	{
		//レイヤー生成
		Layer2D layer = new Layer2D();
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
				layer.Create( w, h );

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
						
						layer.Set( x, y, v );
						x++;
					}
					y++;
				}
			}
		}
		return layer;
	}
}
