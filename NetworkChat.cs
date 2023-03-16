using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkChat : MonoBehaviour 
{
	//Username
	public Text myUsername;
	//Typed words
	public Text inputChat;
	//ChatBox scroll control
	public ScrollRect scrollRect;
	//Increase chatBox size
	public RectTransform chatBoxSize;
	//All text display; by all clients
	public Text displayText;
	//Small chatbox size in MainMenu
	public RectTransform smallChatBoxSize;
	//Small chatbox display in MainMenu
	public Text smallDisplayText;

//	void Awake()
//	{
//		inputChat = GameObject.Find ("PlayerChatInput").GetComponent<Text> ();
//		scrollRect = GameObject.Find ("ScrollRect").GetComponent<ScrollRect> ();
//		chatBoxSize = GameObject.Find ("ChatText").GetComponent<RectTransform> ();
//		displayText = GameObject.Find ("ChatText").GetComponent<Text> ();
//	}
		
	public void Chat(string message)
	{
		if (inputChat.text == "Meow..?") 
		{
			inputChat.text = "";
		}

		if (inputChat.text != "") 
			{
				print ("321");
				message =  myUsername.text + ": " + inputChat.text;
				//CmdChat (message);
				Typing.letters = "";
				inputChat.text = "";
				displayText.text += message;
				displayText.text += "\n";
				chatBoxSize.sizeDelta = new Vector2 (chatBoxSize.sizeDelta.x, chatBoxSize.sizeDelta.y + 54);
				smallDisplayText.text += message;
				smallDisplayText.text += "\n";
				smallChatBoxSize.sizeDelta = new Vector2 (smallChatBoxSize.sizeDelta.x, smallChatBoxSize.sizeDelta.y + 54);
//			scrollRect.GetComponent<ScrollRect> ().verticalNormalizedPosition = 0f;
			}
//		if (chatBoxSize.sizeDelta.y >= 2700f) 
//		{
//			chatBoxSize.sizeDelta = new Vector2 (chatBoxSize.sizeDelta.x, 2700f);
//		}
	}

	public void Meow()
	{
		inputChat.text = "Meow..?";
	}

//	[Command]
//	void CmdChat(string message)
//	{
//		RpcChat (message);
//		Debug.Log ("abc");
//	}
//
//
//	[ClientRpc]
//	void RpcChat(string message)
//	{
//		displayText.text += message;
//		displayText.text += "\n";
//		chatBoxSize.sizeDelta = new Vector2 (chatBoxSize.sizeDelta.x, chatBoxSize.sizeDelta.y + 54);
//		scrollRect.GetComponent<ScrollRect> ().verticalNormalizedPosition = 0f;
//		Debug.Log ("def");
//	}
}
