﻿using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;

public class ButtonScript1 : MonoBehaviour {

	// Use this for initialization
	public void ChangeMenu () {
		SceneManager.LoadScene ("GameBoard"); 

	} 

	public void QuitApp () {

		Application.Quit (); 

	} 
	/*
	public void Backtomenu () {
		SceneManager.LoadScene ("Menu"); 

	} */

}
