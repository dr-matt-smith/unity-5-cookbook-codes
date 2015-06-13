// file: PauseGame.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to pause a game
 * and change quality settings 
 */ 
public class PauseGame : MonoBehaviour {
	// GUI panel for the pause screen
	public GameObject qPanel;

	// GUI slider for adjusting quality settings from the pause screen
	public GameObject qSlider;

	// GUI Text label for quality settings
	public GameObject qLabel;

	// Boolean variable for adotping expensive changes (anti-alias, etc.) when changing quality settings
	public bool expensiveQualitySettings = true;

	// Boolean variable that informs script if game should be paused or not, false by default.
	private bool isPaused = false;

	/* ----------------------------------------
	 * At Start, make mouse cursor invisible, adjust UI Slider settings 
	 * and set UI Panel inactive.
	 */ 	
	void Start () {
		// Make cursor invisible based on 'isPaused' boolean 
		Cursor.visible = isPaused;

		// Set a variable for the Slider component of the GUI slider
		Slider slider = qSlider.GetComponent<Slider> ();

		// Set number of available quality settings as the maximum value of the GUI slider
		slider.maxValue = QualitySettings.names.Length;

		// Set current Quality Level as the current value of the GUI slider
		slider.value = QualitySettings.GetQualityLevel ();

		// Set GUI panel inactive
		qPanel.SetActive(false);
	}

	/* ----------------------------------------
	 * Whenever 'ESC' key is pressed, toggle 'isPaused' boolean 
	 * and call SetPause() to pause/resume game 
	 */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// IF 'Esc' key is pressed, THEN invert boolean 'isPaused'
			isPaused = !isPaused;
			//... and call SetPause() function
			SetPause ();
		}
	}

	/* ----------------------------------------
	 * A function to pause/resume the game   
	 */
	private void SetPause(){
		// Invert 'isPaused' boolean and convert it into a float variable, being true = 1; and false = 0f.  
		float timeBoolean = !isPaused ? 1f : 0f;

		// Set the Time Scale as 1(game runs normally) or 0(game pauses)
		Time.timeScale = timeBoolean;

		// Turn mouse cursor visibility on/off
		Cursor.visible = isPaused;

		// Enable/Disable mouse movement of First Person Controller from our example scene.
		GetComponent<MouseLook> ().enabled = !isPaused;

		// Set UI panel active/inactive
		qPanel.SetActive (isPaused);
	}

	/* ----------------------------------------
	 * A function to change quality settings to be accessed from
	 * the UI Slider
	 */
	public void SetQuality(float qs){
		// Convert UI slider float to Int
		int qsi = Mathf.RoundToInt (qs);

		// Set Quality level to Int value from UI slider
		QualitySettings.SetQualityLevel (qsi);

		// Set a variable for the Text component of the GUI text label
		Text label = qLabel.GetComponent<Text> ();

		// Set the name of the chosen quality level as text of GUI text label
		label.text = QualitySettings.names [qsi];
	}
}
