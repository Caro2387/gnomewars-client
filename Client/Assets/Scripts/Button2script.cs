using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class Button2script : MonoBehaviour {

	Text newText, newText1, newText2;

	void Start() {

		newText = GameObject.Find("Player1B").GetComponentInChildren<Text> ();
		newText1 = GameObject.Find("Player2B").GetComponentInChildren<Text> ();
		newText2 = GameObject.Find("Player3B").GetComponentInChildren<Text> ();

	}

	public void changeText() {
		newText.text = "Something";
	} 

	public void changeText1() {
		newText1.text = "Somethingelse";
	}

	public void changeText2() {
		newText2.text = "Somethingthird";
	}

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



	public void Awake()
	{


	}
}
