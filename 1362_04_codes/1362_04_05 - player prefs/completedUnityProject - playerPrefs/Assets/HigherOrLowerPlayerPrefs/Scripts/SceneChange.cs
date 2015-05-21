using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {
	public void GotoScene(int sceneNumber){
		Application.LoadLevel(sceneNumber);
	}
}
