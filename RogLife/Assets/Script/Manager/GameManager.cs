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
	private Player _Player;
	private Actor _PlayerActor;
	private GameObject[] _EnemyInstances;
	private Enemy[] _Enemys;

	[SerializeField]
	private SaveDataManager _SaveManager;

	private InputManager _InputManager;

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
		SetUpCharactorParam();

		SetUpCamera();

		_SaveManager.SetUp();

		_InputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
		if( _InputManager == null ){
			Debug.Log("ERROR InputManager");
		}
		SetUpInputManager();
	}

	private void SetUpCharactor()
	{
		_PlayerInstance = Instantiate( _PlayerPrefab,
										_PlayerSpownPoint.position,
										_PlayerSpownPoint.rotation ) as GameObject;
		_Player = _PlayerInstance.GetComponent<Player>();
		_PlayerActor = _PlayerInstance.GetComponent<Actor>();
		if( _Player == null ){
			Debug.Log( "ERROR player" );
		}
		_Player.SetUp();

		_EnemyInstances = new GameObject[_EnemyPrefabs.Length];
		_Enemys = new Enemy[_EnemyPrefabs.Length];

		for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
			_EnemyInstances[i] = Instantiate(  _EnemyPrefabs[i],
												_EnemySpownPoints[i].position,
												_EnemySpownPoints[i].rotation ) as GameObject;
			_Enemys[i] = _EnemyInstances[i].GetComponent<Enemy>();
			if( _Enemys[i] == null ){
				Debug.Log( "ERROR enemy" );
			}
			_Enemys[i].SetUp();
		}
	}

	private void SetUpCharactorParam()
	{
		CharacterParam param = new CharacterParam();
		//後でファイルから読み込むようにする
		param._ID = 0;
		param._Level = 1;
		param._HP = 10;
		param._HPMax = 10;
		param._Str = 3;
		param._Exp = 0;

		_PlayerActor.Param = param;
	}

	private void SetUpCamera()
	{
		_Camera.SetUp( _PlayerInstance );
	}

	private void SetUpInputManager()
	{
		_InputManager._ActionUpArrow += ActionUp;
		_InputManager._ActionDownArrow += ActionDown;
		_InputManager._ActionLeftArrow += ActionLeft;
		_InputManager._ActionRightArrow += ActionRight;
	}

	private void ActionUp()
	{
		Debug.Log("PRESS Up");
		ActionUpdate( eDir.UP );
	}

	private void ActionDown()
	{
		Debug.Log("PRESS Down");
		ActionUpdate( eDir.DOWN );
	}

	private void ActionLeft()
	{
		Debug.Log("PRESS Left");
		ActionUpdate( eDir.LEFT );
	}

	private void ActionRight()
	{
		Debug.Log("PRESS Right");
		ActionUpdate( eDir.RIGHT );
	}

	private void ActionUpdate( eDir dir )
	{
		_Player.Move( dir );
		// キャラクターの移動アニメーションからカメラをUpdateする必要がある
		//_Camera.Move();

		_Player.Attack( dir );
	}
}
