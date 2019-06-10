using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanelManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _MapPanel;

	[SerializeField]
	private MapManager _MapManager;

	[SerializeField]
	private GameObject _PanelPrefab;

	private Layer2D _layer;

	private GameObject[,] _Panels;
	private int MapHeight;
	private int MapWidth;

	public void SwitchMapPanelActive()
	{
		if( _MapPanel.activeInHierarchy == true ){
			DeleteMap();

			_MapPanel.SetActive( false );
		}
		else{
			_MapPanel.SetActive( true );

			CreateMap();
		}
	}

	public void SetUp()
	{
		_layer = _MapManager.MapData;
		MapHeight = _layer._height;
		MapWidth = _layer._height;

		_Panels = new GameObject[MapHeight,MapWidth];
	}

	/* マップの更新 */
	void CreateMap()
	{
		for( int h = 0; h < MapHeight; h++ ){
			for( int w = 0; w < MapWidth; w++ ){
				int Panel = _layer.Get( w, h );
				if( Panel == (int)eMapElement.WALL ){
					SetPanelParam(h, w);
					_Panels[h,w].GetComponent<Image>().color = Color.black;
				}
				else if( Panel == (int)eMapElement.STAIRS ){
					SetPanelParam(h, w);
					_Panels[h,w].GetComponent<Image>().color = Color.blue;
				}
				else if( Panel == (int)eMapElement.PLAYER ){
					SetPanelParam(h, w);
					_Panels[h,w].GetComponent<Image>().color = Color.green;
				}
				else if( Panel == (int)eMapElement.ENEMY ){
					SetPanelParam(h, w);
					_Panels[h,w].GetComponent<Image>().color = Color.red;
				}
			}
		}
	}

	void SetPanelParam( int h, int w)
	{
		_Panels[h,w] = Instantiate( _PanelPrefab );
		_Panels[h,w].GetComponent<RectTransform>().anchoredPosition = new Vector2(w * 50, h * 50);
		_Panels[h,w].transform.SetParent(_MapPanel.transform, false);
	}

	void DeleteMap()
	{
		for( int h = 0; h < MapHeight; h++ ){
			for( int w = 0; w < MapWidth; w++ ){
				Destroy( _Panels[h,w] );
			}
		}
	}
}
