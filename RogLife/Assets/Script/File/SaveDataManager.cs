using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{
	[SerializeField]
	private SaveData _SaveData;
	[SerializeField]
	private GameObject _Player;
	[SerializeField]
	private MapManager _MapData;

	private const string SAVE_FILE_PATH = "SaveData.txt";

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.S ) ){
			_SaveData = new SaveData();
			_SaveData._PlayerPos = _Player.transform.position;
			_SaveData._width = _MapData.Width;
			_SaveData._height = _MapData.Height;
			_SaveData._vals = _MapData.Value;

			string json = JsonUtility.ToJson( _SaveData );
			string path = Application.dataPath + "/" + SAVE_FILE_PATH;
			Debug.Log( path );
			StreamWriter witer = new StreamWriter( path, false );
			witer.WriteLine( json );
			witer.Flush();
			witer.Close();
		}
		else if( Input.GetKeyDown( KeyCode.L ) ){
			FileInfo info = new FileInfo( Application.dataPath + "/" + SAVE_FILE_PATH );
			StreamReader reader = new StreamReader( info.OpenRead() );
			string json = reader.ReadToEnd();
			reader.Close();
			SaveData data = JsonUtility.FromJson<SaveData>( json );
			data.Dump();
			_Player.transform.position = data._PlayerPos;
			_MapData.Width = data._width;
			_MapData.Height = data._height;
			_MapData.Value = data._vals;
		}
	}
}
