using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class Button2script : MonoBehaviour {

	// Use this for initialization
	public void Backtomenu () {
		SceneManager.LoadScene ("Menu"); 

	} 



	public void OnGui (){
		
		bool buttonClicked = false; 
		if(buttonClicked)
			GUI.color = Color.red;


	}

}
