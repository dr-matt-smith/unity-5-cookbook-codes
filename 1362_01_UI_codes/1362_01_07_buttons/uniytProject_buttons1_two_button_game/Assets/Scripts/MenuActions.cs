using UnityEngine;
using System.Collections;

public class MenuActions : MonoBehaviour {
	public void MENU_ACTION_GotoPage(string sceneName){
		Application.LoadLevel(sceneName);
	}	
}