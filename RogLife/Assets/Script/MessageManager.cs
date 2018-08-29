using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _Canvase;
	//メッセージテキスト
	[SerializeField]private Text[] MessageTextList;
	//テキストキュー
	private Queue<string> TextQueue = new Queue<string>();

	public void AddMessage( string message )
	{
		if( TextQueue.Count == MessageTextList.Length ){
			TextQueue.Dequeue();
		}
		TextQueue.Enqueue(message);
	}

	void Start()
	{
		_Canvase.SetActive( true );
		for( int i = 0; i < MessageTextList.Length; i++ ){
			MessageTextList[i].text = "";
		}
	}

	void Update()
	{
		int i = 0;
		foreach( string message in TextQueue ){
			MessageTextList[i].text = message;
			i++;
		}
	}
}
