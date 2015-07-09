using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {
	public void BUTTON_ACTION_make_green(){ 
		PublishColorEvent( Color.green ); 
	}

	public void BUTTON_ACTION_make_blue(){ 
		PublishColorEvent( Color.blue ); 
	}

	public void BUTTON_ACTION_make_red(){ 
		PublishColorEvent( Color.red ); 
	}

	public delegate void ColorChangeHandler(Color newColor);
	public static event ColorChangeHandler onChangeColor;

	private void PublishColorEvent(Color newColor){
		// if there is at least one listener to this delegate
		if( onChangeColor != null){
			// broadcast change colour event 
			onChangeColor( newColor );
		}
	}
}