﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using baseCode ;

public class FirstSceneGuiCtrl : MonoBehaviour {
	firstScenceUserAction action ;
	bool ifShowHelp = true;
	string helpText = "目标：让所有牧师和恶魔都到右岸，规则：点击牧师或者恶魔可以上岸或者上船，任意一边岸的恶魔" +
	                  "数量若多于牧师（包括那一边船里的人物），那么游戏失败。";
	// Use this for initialization
	void Start () {
		action = Director.getInstance().currentSceneController as firstScenceUserAction;
	}
	
	// Update is called once per frame
	void OnGUI () {
		firstScenceUserAction action = Director.getInstance().currentSceneController as firstScenceUserAction;
		string status = action.getStatus ();
		if (ifShowHelp == true) {
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 180), "" );
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 180), helpText);
			if(	GUI.Button (new Rect (Screen.width / 2 - 20, Screen.height / 2 + 60, 40, 30), "Ok") ){
				ifShowHelp = false;

			} 

		}

		if (GUI.Button (new Rect(10 , 10 , 100, 50), "帮助") ) {
			ifShowHelp = true;
		}



		if (status == "playing") {
			if (GUI.Button (new Rect(130 , 10 , 100, 50), "重新开始")) {
				action.reset ();
			}
		}
		else {
			string showMsg;
			if (status == "lost") {
				showMsg = "你输了!";
			}
			else {
				showMsg = "你赢了!";
			}
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50), showMsg) ) {
				action.reset ();
			}
		}

		if (GUI.Button (new Rect(250 , 10 , 100, 50), "提示")) {
			action.nextStep ();
		}
	}
}
