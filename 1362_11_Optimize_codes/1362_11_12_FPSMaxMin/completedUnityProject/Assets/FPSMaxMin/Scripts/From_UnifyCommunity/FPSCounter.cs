/* **************************************************************************
 * FPS COUNTER
 * **************************************************************************
 * Written by: Annop "Nargus" Prapasapong
 * Created: 7 June 2012
 * 
 * Adapted for min/max/no-display by: Matt Smith, 29 November 2014
 * 
 * URL: http://wiki.unity3d.com/index.php?title=FramesPerSecond
 * shared under Creative Commons
 * *************************************************************************/

using UnityEngine;
using System.Collections;

/* **************************************************************************
 * CLASS: FPS COUNTER
 * *************************************************************************/ 
[RequireComponent(typeof(GUIText))]
public class FPSCounter : MonoBehaviour {
	/* Public Variables */
	public float frequency = 0.5f;
	public bool displayWhileRunning = true;

	/* **********************************************************************
	 * PROPERTIES
	 * *********************************************************************/
	public int FramesPerSec { get; protected set; }

	private GUIText guiText;

	private int minFPS = 1000;
	private int maxFPS = -1;

	
	/* **********************************************************************
	 * EVENT HANDLERS
	 * *********************************************************************/
	/*
	 * EVENT: Start
	 */
	private void Start() {
		guiText = GetComponent<GUIText>();
		StartCoroutine(FPS());
	}
	
	/*
	 * EVENT: FPS
	 */
	private IEnumerator FPS() {
		for(;;){
			// Capture frame-per-second
			int lastFrameCount = Time.frameCount;
			float lastTime = Time.realtimeSinceStartup;
			yield return new WaitForSeconds(frequency);
			float timeSpan = Time.realtimeSinceStartup - lastTime;
			int frameCount = Time.frameCount - lastFrameCount;
			
			// Max / Min update
			FramesPerSec = Mathf.RoundToInt(frameCount / timeSpan);
			if(FramesPerSec > maxFPS) 
				maxFPS = FramesPerSec;
			else if(FramesPerSec < minFPS) 
				minFPS = FramesPerSec;

			// display while game runing?
			if(displayWhileRunning)
				DisplayAsGUIText();
		}
	}

	private void DisplayAsGUIText(){
		string msg = FramesPerSec.ToString() + " fps";
		msg += "\n max = " + maxFPS;
		msg += "\n min = " + minFPS;
		guiText.text = msg;
	}

	private void OnApplicationQuit(){
		string msg = "Frames Per Second: max = " + maxFPS + ", min = " + minFPS;
		print (msg);
	}
	

}