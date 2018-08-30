using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
	[SerializeField]
	private GameObject _target;

	private Vector3 _margin;

	void Start()
	{
		_margin = _target.transform.position;
	}

	void Update()
	{
		transform.position += _target.transform.position - _margin;
		_margin = _target.transform.position;
	}
}
