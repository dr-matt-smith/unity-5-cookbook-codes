using UnityEngine;
using System.Collections;

public class LoadMazeFromTextfile : MonoBehaviour 
{
	// text file containing level data
	public TextAsset levelDataTextFile;
	
	/** prefab for Pacman object */
	public GameObject pacmanPrefab;
	
	/** prefab for Pellet object */
	public GameObject pelletPrefab;
	
	/** prefab for PowerPill object */
	public GameObject powerPillPrefab;
	
	/** prefab for Wall object */
	public GameObject wallPrefab;
	
	//-------------------------------
	/**
	 * calls methods to create each ROW of the scene
	 */
	void Awake() 
	{
		// (1) declare a newline character variable
		char newlineChar = '\n';

		// (2) read in and make array from level data		
    	string[] stringArray = levelDataTextFile.text.Split(newlineChar);

		// (3) call the method to build this maze
		BuildMaze( stringArray );
	}
	
	//-------------------------------
	/**
	 * create objects on screen as defined by this string array
	 */
	void BuildMaze(string[] stringArray)
	{
		// count the number of rows in the string array
		int numRows = stringArray.Length;
//		int numCols = stringArray[0].Length;

		// get screen widht and height
//		float screenWidth = Screen.width;
//		float screenHeight = Screen.height;

//		float spriteWidth = 64f;
//		float spriteHeight = 64f;
		
		// x-scaling factor = screenWidth / numCOls // sprite width?
		// y-scaling factor = screenHight / numRows // sprite height
//		float xScale = screenWidth / numCols / spriteWidth;
//		float yScale = screenHeight / numRows / spriteHeight;



		//
		// pixels to units
		//
		//

		// change size of sprite - to fill whole screen
		// http://answers.unity3d.com/questions/701188/sprite-resized-to-whole-screen.html

		// now we know how many rows
		// we can calcualte the Z-offset
		float yOffset = (numRows / 2);
		
		// loop for each row of the array
		for(int row=0; row < numRows; row++)
		{
			// extract the string for the current row
			string currentRowString = stringArray[row];
			
			// calculate the Y value for this row
			float y = -1 * (row - yOffset);

			// now call CreateRow for this string at this Y position
			CreateRow(currentRowString, y);
		}
	}
	
	//-------------------------------
	/**
	 * create a row of the scene given a string like "X..p...X"
	 */
	void CreateRow(string currentRowString, float y) 
	{
		// calculate X-offset based on Lenth of the string (numChars)
		int numChars = currentRowString.Length;
		float xOffset = (numChars/2);
	
		// loop for each character in the row string
		for(int charPos = 0; charPos < numChars; charPos++)
		{
			float x = (charPos - xOffset);

			char prefabCharacter = currentRowString[charPos];
			CreatePrefabInstanceFromCharacter(prefabCharacter, x, y);			
		}
	}
	
	//-------------------------------
	/**
	 * create instance for appropriate prefab
	 * depending on provided character
	 */
	void CreatePrefabInstanceFromCharacter(char prefabCharacter, float x, float y)
	{
		GameObject prefab;

		print ("prefabCharacter = " + prefabCharacter);

		switch(prefabCharacter)
		{
		case '.':
			prefab = pelletPrefab;
			CreatePrefabInstance( prefab, x, y);
			break;
			
		case 'O':
			prefab = powerPillPrefab;
			CreatePrefabInstance( prefab, x, y);
			break;
			
		case 'p':
			prefab = pacmanPrefab;
			CreatePrefabInstance( prefab, x, y);
			break;
			
		case 'X':
			prefab = wallPrefab;
			CreatePrefabInstance( prefab, x, y);
			break;

		default:
			// don't create anything
			// if we don't recognise the character
			break;
		}
	}
	
	//-------------------------------
	/**
	 * create instance of given Prefab 
	 * at position (x, 1, z) 
	 */
	void CreatePrefabInstance(GameObject objectPrefab, float x, float y)
	{
		// all objects are to be created at Y = 1
		float z = 0;
	
		// create new position Vector
		Vector3 position = new Vector3(x, y, z);
		
		// create no rotation Quaternion
		Quaternion noRotation = Quaternion.identity;
		
		// create Prefab instance
		Instantiate (objectPrefab, position, noRotation);
	}

} // class

