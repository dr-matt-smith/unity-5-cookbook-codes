// file: TakeScreenshot.cs
using UnityEngine;
using System.Collections;
using System;
using System.IO;
/* ----------------------------------------
 * class to demonstrate how to take screenshots at runtime
 * using two different methods: Unity's built-in CaptureScreenshot function
 * and a combination of ReadPixels, EncodeToJPG (or EncodeToPNG) and WriteAllBytes.
 */ 
public class TakeScreenshot : MonoBehaviour {
	// String variable for a prefix for the screenshot's name 
	public string prefix = "Screenshot";
	// A selector for the screenshot taking method
	public enum method{captureScreenshotPng, ReadPixelsPng, ReadPixelsJpg};
	// Set initial value for 'method' as 'captureScreenshotPng' 
	public method captMethod = method.captureScreenshotPng;
	// Int value by which to increase the resolution of screenshots taken via CaptureScreenshot method
	public int captureScreenshotScale = 1;	
	// A slider from 0 to 100 from which to set JPG quality 
	[Range(0, 100)]
	// Int variable for JPG quality
	public int jpgQuality = 75;
	// Private Texture2D variable where to storage image capture via ReadPixels
	private Texture2D texture;
	
	/* ----------------------------------------
	 * During Update, detect if the 'P' key was pressed, 
	 * starting a couroutine (TakeShot), if so
	 */
	void  Update (){
		if (Input.GetKeyDown (KeyCode.P))
			// IF 'P' is pressed on the keyboard, THEN start coroutine
			StartCoroutine(TakeShot());
	}
	
	/* ----------------------------------------
	 * A coroutine where the screenshot is taken according to the preferences 
	 * set by the user 
	 */
	IEnumerator  TakeShot (){
		// String for date and time the screenshot was taken, to be added to the image file's name
		string date = System.DateTime.Now.ToString("_d-MMM-yyyy-HH-mm-ss-f");
		// Int variable for the screen's width
		int sw = Screen.width;
		// Int variable for the screen's height
		int sh = Screen.height;
		// Rect variable for the image capture area
		Rect sRect = new Rect(0,0,sw,sh);
		// bytes array for converting pixels to image format
		byte[] bytes;
		// String variable for the file format suffix, to be added to the image file's name
		string format;
		
		// IF selected method is 'captureScreenshotPng'...
		if (captMethod == method.captureScreenshotPng){
			// THEN use Unity's CaptureScreenshot function to capture screenshot, increased by 'captureScreenshotScale';
			Application.CaptureScreenshot(prefix + date + ".png", captureScreenshotScale);	
			// ELSE, if selected method is NOT 'captureScreenshotPng'...
		} else {
			// Wait for the end of the frame, so GUI elements are included in the screenshot
			yield return new WaitForEndOfFrame();
			// Create new Texture2D variable of the same size as the image capture area 
			texture = new Texture2D (sw,sh,TextureFormat.RGB24,false);	
			// Read Pixels from the capture area
			texture.ReadPixels(sRect,0,0);
			// Apply pixels read com capture area into 'texture'
			texture.Apply();
			
			// IF selected method is 'ReadPixelsJpg'...
			if (captMethod == method.ReadPixelsJpg){
				// store as bytes the texture encoded to JPG (using 'jpgQuality' as quality settings) 
				bytes= texture.EncodeToJPG(jpgQuality);
				// Set format suffix, to be added to the image file's name, as ".jpg"
				format = ".jpg";
				// Destroy 'texture' 
				Destroy (texture);
				// Write bytes as file named after 'prefix", 'date' and 'format' strings 
				File.WriteAllBytes(Application.dataPath + "/../"+prefix + date + format, bytes);
				
				// ELSE, IF selected method is 'ReadPixelsPng'..
			} else if (captMethod == method.ReadPixelsPng){
				// store as bytes the texture encoded to PNG
				bytes= texture.EncodeToPNG();
				// Set format suffix, to be added to the image file's name, as ".jpg"
				format = ".png";
				// Destroy 'texture' 
				Destroy (texture);
				// Write bytes as file named after 'prefix", 'date' and 'format' strings 
				File.WriteAllBytes(Application.dataPath + "/../"+prefix + date + format, bytes);
			}
		}
	}
} 
