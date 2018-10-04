using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
	private GameObject _Target;

	private Vector3 _Margin = Vector3.zero;

	public void SetUp( GameObject target )
	{
		if( target == null ){
			Debug.Log( "ERROR FollowPlayerCamera SetUp" );
		}
		_Target = target;
		_Margin = _Target.transform.position;
	}

	public void Move()
	{
		if( _Target == null ){
			Debug.Log( "ERROR FollowPlayerCamera Move" );
		}
		transform.position += _Target.transform.position - _Margin;
		_Margin = _Target.transform.position;
	}
}
