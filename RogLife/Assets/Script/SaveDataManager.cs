﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{
	[SerializeField]
	private SaveData _SaveData;
	[SerializeField]
	private Transform _Player;
	[SerializeField]
	private Movement _Movement;
	[SerializeField]
	private TMXLoader _Map;

	private const string SAVE_FILE_PATH = "SaveData.txt";

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.S ) ){
			_SaveData = new SaveData();
			_SaveData._PlayerPos = _Player.position;
			_SaveData._LockAt = _Movement.PlayerLockAt;
			_SaveData._width = _Map.LayerWidth;
			_SaveData._height = _Map.LayerHeight;
			_SaveData._vals = _Map.LayerValue;

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
			SaveData data = JsonUtility.FromJson<SaveData>( json );
			data.Dump();
		}
	}
}
