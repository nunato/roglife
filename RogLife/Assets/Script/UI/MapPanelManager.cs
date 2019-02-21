using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanelManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _MapPanel;

	public void SwitchMapPanelActive()
	{
		if( _MapPanel.activeInHierarchy == true ){
			_MapPanel.SetActive( false );
		}
		else{
			_MapPanel.SetActive( true );
		}
	}
}
