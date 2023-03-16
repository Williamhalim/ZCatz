using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Chat : NetworkBehaviour 
{
//	private List<string> chatHistory = new List<string>();
//  NOT IN USE.

	public ScrollRect scrollRect;

	private Text chatText;
	private RectTransform chatBoxSize;
	private InputField chatInput;

	void Start()
	{
		chatText = GameObject.Find ("ChatText").GetComponent<Text> ();
		chatBoxSize = GameObject.Find ("ChatText").GetComponent<RectTransform> ();
		chatInput = GameObject.Find ("ChatInput").GetComponent<InputField> ();
	}

	void Update()
	{
		if (chatInput.text != "" && Input.GetButtonDown("Submit")) 
		{
			chatText.text += "myUsername : " + chatInput.text;
			chatText.text += "\n";
			chatInput.text = "";
			chatBoxSize.sizeDelta = new Vector2 (chatBoxSize.sizeDelta.x, chatBoxSize.sizeDelta.y + 30);
			GameObject.Find ("ScrollRect").GetComponent<ScrollRect> ().verticalNormalizedPosition = 0;
			chatInput.ActivateInputField ();
			chatInput.Select ();
		}
	}

	public void chat(string message)
	{
		CmdChat(message);
	}

	[Command]
	void CmdChat(string message)
	{
		RpcChat (message);
	}

	[ClientRpc]
	void RpcChat(string message)
	{
		chatText.text += message;
		chatText.text += "\n";
	}
}
