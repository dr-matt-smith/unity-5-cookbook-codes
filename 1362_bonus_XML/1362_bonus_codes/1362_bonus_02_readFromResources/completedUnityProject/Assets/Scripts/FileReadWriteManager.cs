// file: FileReadWriteManager.cs
using System;
using System.IO; 

public class FileReadWriteManager {
	public void WriteTextFile(string pathAndName, string stringData) { 
		// remove file (if exists)
		FileInfo textFile = new FileInfo(  pathAndName ); 
		if( textFile.Exists ) 
	         textFile.Delete(); 
		
		// create new empty file
		StreamWriter writer; 
		writer = textFile.CreateText(); 
		
		// write text to file
		writer.Write(stringData); 
		
		// close file
		writer.Close(); 
	} 
	
	public string ReadTextFile(string pathAndName) { 
		string dataAsString = "";
		
		try {
			// open text file
			StreamReader textReader = File.OpenText( pathAndName ); 
			
			// read contents
			dataAsString = textReader.ReadToEnd(); 
			
			// close file
			textReader.Close(); 
			
		}	
		catch (Exception e) {
//			display/set e.Message error message here if you wish  ...
		}
		
		// return contents
		return dataAsString; 
	} 
} 
