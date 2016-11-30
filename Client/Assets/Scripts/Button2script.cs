using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class Button2script : MonoBehaviour {




	// Use this for initialization
	public void Backtomenu () {
		SceneManager.LoadScene ("Menu"); 

	} 



	public void changeColor ()
	{
		Image button1 = GameObject.Find("Player1B").GetComponent<Image>();
		button1.color = Color.red;

		 
	} 

	public void changeColor2 ()
	{
		Image button1 = GameObject.Find("Player2B").GetComponent<Image>();
		button1.color = Color.red;

	} 

	public void changeColor3 ()
	{
		Image button1 = GameObject.Find("Player3B").GetComponent<Image>();
		button1.color = Color.red;

	} 


}
