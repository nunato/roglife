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

	// ゲーム状態
	private eSequence _Sequence = eSequence.SETUP;

	public eSequence GameSequence
	{
		set{
			_Sequence = value;
		}
		get{ return _Sequence;}
	}

	private GameObject _PlayerInstance;
	private Player _Player;
	private Actor _PlayerActor;
	private GameObject[] _EnemyInstances;
	private Enemy[] _Enemys;
	private Actor[] _EnemyActors;

	[SerializeField]
	private MapManager _MapManager;
	[SerializeField]
	private SaveDataManager _SaveManager;
	[SerializeField]
	private InputManager _InputManager;
	[SerializeField]
	private MapPanelManager _MapPanelManager;

	// 暫定
	private eDir OldDir = eDir.NONE;

	// 暫定のParamの取得
	// ユニークIDをどこから取ってくるのか考える
	public CharacterParam? GetCharacterParamFromId( int Id )
	{
		for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
			Actor _EnemyActor = _EnemyInstances[i].GetComponent<Actor>();
			if ( _EnemyActor.Param._ID == Id ){
				return _EnemyActor.Param;
			}
		}
		return null;
	}

	// マップマネージャのポジションからActerにアクセスしてIDを返す
	// プレイヤーか敵かは関係ない
	// そのため今の配列ではわからない
	// マップポジションをActorで持つようにしてそこからIDまで取れるようにしないと
	public int? GetCharacterId( Vector2 targetMapPos )
	{
		if( _PlayerActor.GetMapPosition( ) == targetMapPos ){
			return _PlayerActor.Param._ID;
		}
		
		for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
			if( _EnemyActors[i].GetMapPosition( ) == targetMapPos ){
				return _EnemyActors[i].Param._ID;
			}
		}
		return null;
	}

	void Start()
	{
		if( _PlayerPrefab		== null	||
			_EnemyPrefabs		== null	||
			_Camera				== null	||
			_PlayerSpownPoint	== null	||
			_EnemySpownPoints	== null	){
			Debug.Log( "ERROR GameManager Start" );
		}
		_MapManager.SetUp();

		SetUpCharactor();

		_MapPanelManager.SetUp();

		SetUpCamera();

		_SaveManager.SetUp();

		SetUpInputManager();

		// キー入力待ちにする
		GameSequence = eSequence.KEY_INPUT;
	}

	private void SetUpCharactor()
	{
		_PlayerInstance = Instantiate(  _PlayerPrefab,
										_PlayerSpownPoint.position,
										_PlayerSpownPoint.rotation ) as GameObject;
		_Player = _PlayerInstance.GetComponent<Player>();
		if( _Player == null ){
			Debug.Log( "ERROR player" );
		}
		_Player.SetUp();
		SetUpPlayerParam();

		_EnemyInstances = new GameObject[_EnemyPrefabs.Length];
		_Enemys = new Enemy[_EnemyPrefabs.Length];
		_EnemyActors = new Actor[_EnemyPrefabs.Length];

		for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
			_EnemyInstances[i] = Instantiate(   _EnemyPrefabs[i],
												_EnemySpownPoints[i].position,
												_EnemySpownPoints[i].rotation ) as GameObject;
			_Enemys[i] = _EnemyInstances[i].GetComponent<Enemy>();
			if( _Enemys[i] == null ){
				Debug.Log( "ERROR enemy" );
			}
			_Enemys[i].SetUp();
			SetUpEnemyParam();
		}
	}

	private void SetUpPlayerParam()
	{
		CharacterParam param;
		// 後でファイルから読み込むようにする
		param._ID = 0;
		param._Level = 1;
		param._HP = 10;
		param._HPMax = 10;
		param._Str = 3;
		param._Exp = 0;
		param._XP = 0;

		_PlayerActor = _PlayerInstance.GetComponent<Actor>();
		_PlayerActor.Param = param;
	}

	private void SetUpEnemyParam()
	{
		CharacterParam param;
		// 後でファイルから読み込むようにする
		param._ID = 1;
		param._Level = 1;
		param._HP = 5;
		param._HPMax = 5;
		param._Str = 1;
		param._Exp = 0;
		param._XP = 2;
		for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
			_EnemyActors[i] = _EnemyInstances[i].GetComponent<Actor>();
		//	_EnemyActors[i].Param = param;
		}
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
		_InputManager._ActionMKey += ActionMKey;
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

	private void ActionMKey()
	{
		_MapPanelManager.SwitchMapPanelActive();
	}

	private void ActionUpdate( eDir dir )
	{
		if( GameSequence == eSequence.KEY_INPUT ){
			_Player.Move( dir );
			OldDir = dir;
			// キャラクターの移動アニメーションからカメラをUpdateする必要がある
			//_Camera.Move();

			// _Player.Attack( dir );
		}
	}

	void Update()
	{
		if( GameSequence == eSequence.PLAYER_MOVE_END ){
			for( int i = 0; i < _EnemyPrefabs.Length; i++ ){
				_Enemys[i].Move( OldDir );
			}
		}

		if( GameSequence == eSequence.MOVE_END ){
			GameSequence = eSequence.KEY_INPUT;
		}
	}
}
