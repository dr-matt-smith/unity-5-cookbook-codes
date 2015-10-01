using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{
	// button action - tell listening objects to go GREEN
	public void BUTTON_ACTION_make_green()
	{
		PublishColorEvent( Color.green ); 
	}

	// button action - tell listening objects to go BLUE
	public void BUTTON_ACTION_make_blue()
	{
		PublishColorEvent( Color.blue ); 
	}

	// button action - tell listening objects to go RED
	public void BUTTON_ACTION_make_red()
	{
		PublishColorEvent( Color.red ); 
	}

    /*---------------------------------------------------------------------------------
     * declare 'ColorChangeHandler' delegate with 'signature' void and 1 param (Color)
     * mmethods matching this signature can be delegted (subscribed) to an event
     *
     */
	public delegate void ColorChangeHandler(Color newColor);

    /*---------------------------------------------------------------------------------
     * declare 'onChangeColor' as an event to maintain list of registered listener methods
     * and to broadcast messages to all registered listeners
     */
	public static event ColorChangeHandler onChangeColor;

	/*-------------------------------------------------------
	 * if there any are (0 or more) listening objects
	 * THEN publish an 'onChangeColor()' message with the given color
	 */
	private void PublishColorEvent(Color newColor)
	{
		// if there is at least one listener to this delegate
		if (onChangeColor != null){
			// broadcast change colour event to all registered listeners
			//
			// so, for example, our UI Text GameObject has registered its method ChangeColorEvent()
			// to listen to 'onChangeColor' events
			// so it will be called when this 'newColor' is sent out by the 'onChangeColor' event
			//
			onChangeColor( newColor );
		}
	}
}