using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _PlayerPrefab;
	[SerializeField]
	private GameObject[] _EnemyPrefabs;
	[SerializeField]
	private FollowPlayerCamera _Camera;
	[SerializeField]
	private Transform _PlayerSpownPoint;
	[SerializeField]
	private Transform[] _EnemySpownPoints;

	private GameObject _PlayerInstance;
	private GameObject[] _EnemyInstances;

	void Start()
	{
		if( _PlayerPrefab		== null	||
			_EnemyPrefabs		== null	||
			_Camera				== null	||
			_PlayerSpownPoint	== null	||
			_EnemySpownPoints	== null	){
			Debug.Log( "ERROR GameManager Start" );
		}
		SetUpCharactor();
		SetUpCamera();
	}

	private void SetUpCharactor()
	{
		_PlayerInstance = Instantiate( _PlayerPrefab,
										_PlayerSpownPoint.position,
										_PlayerSpownPoint.rotation ) as GameObject;
		Player player = _PlayerInstance.GetComponent<Player>();
		if( player == null ){
			Debug.Log( "ERROR player" );
		}
		player.SetUp();

		_EnemyInstances = new GameObject[_EnemyPrefabs.Length];

		for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
			_EnemyInstances[i] = Instantiate(  _EnemyPrefabs[i],
												_EnemySpownPoints[i].position,
												_EnemySpownPoints[i].rotation ) as GameObject;
			Enemy enemy = _EnemyInstances[i].GetComponent<Enemy>();
			if( enemy == null ){
				Debug.Log( "ERROR enemy" );
			}
			enemy.SetUp();
		}
	}

	private void SetUpCamera()
	{
		_Camera.SetUp( _PlayerInstance );
	}
}
