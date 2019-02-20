using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairsManager : MonoBehaviour
{
	[SerializeField]
	private Text _StairsText;

	private int _StairsCount;

	public void IncrementStairsCount()
	{
		_StairsCount++;
	}

	void Start()
	{
		_StairsCount = 1;
		_StairsText.text = _StairsCount + " F";
	}

	void Update()
	{
		_StairsText.text = _StairsCount + " F";
	}
}
