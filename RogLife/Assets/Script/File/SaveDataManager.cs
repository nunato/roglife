using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{
	private SaveData _SaveData;
	private GameObject _Player;
	private Actor _Actor;
	[SerializeField]
	private MapManager _MapData;

	private const string SAVE_FILE_PATH = "SaveData.txt";

	public void SetUp()
	{
		_Player = GameObject.FindGameObjectWithTag("Player");
		if( _Player == null ){
			Debug.Log( "ERROR SaveDataManager SetUp" );
		}
		_Actor = _Player.GetComponent<Actor>();
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.S ) ){
			_SaveData = new SaveData();

			_SaveData._PlayerPos = _Player.transform.position;

			_SaveData._MapData = _MapData.MapData;

			_SaveData._Param = _Actor.Param;

			_SaveData.Dump();

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
			_MapData.MapData = data._MapData;
			_Actor.Param = data._Param;
		}
	}
}
