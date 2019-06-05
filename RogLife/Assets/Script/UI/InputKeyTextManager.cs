using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeyTextManager : MonoBehaviour
{
	[SerializeField]
	public Text _InputKeyText;

	void Start()
	{
		_InputKeyText.text = "";

		_InputKeyText.text = _InputKeyText.text + "M: Map\n";
		_InputKeyText.text = _InputKeyText.text + "S: Save\n";
		_InputKeyText.text = _InputKeyText.text + "L: Load\n";
	}
}
