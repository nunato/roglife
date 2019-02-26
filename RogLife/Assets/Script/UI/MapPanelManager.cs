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

	public void SwitchMapPanelActive()
	{
		if( _MapPanel.activeInHierarchy == true ){
			_MapPanel.SetActive( false );
		}
		else{
			_MapPanel.SetActive( true );
		}
	}

	public void SetUp()
	{
		_layer = _MapManager.MapData;
		CreateMap();
	}

	/* マップの更新 */
	void CreateMap()
	{
		int MapHeight = _layer._height;
		int MapWidth = _layer._height;

		for( int h = 0; h < MapHeight; h++ ){
			for( int w = 0; w < MapWidth; w++ ){
				int Panel = _layer.Get( w, h );
				if( Panel == (int)eMapElement.WALL ){
					Vector3 position = new Vector3(w * 100, h * 100, 0 );
					Debug.Log(position);
					GameObject panel = Instantiate( _PanelPrefab );
					panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(w * 100, h * 100);
					panel.transform.SetParent(_MapPanel.transform, false);
				}
				else if( Panel == (int)eMapElement.STAIRS ){

				}
			}
		}
	}
}
