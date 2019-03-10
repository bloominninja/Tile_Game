using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hex : MonoBehaviour 
	{
	//Coords in maparray
	public int x;
	public int y;

	//the devil is a handsom man
	//Get neighbours
	public Hex[] GetN()
	{
		List<GameObject> Test=new List<GameObject>();
		List<Hex> T2=new List<Hex>();
		//Hex[] Array = new Hex[2];
		//Get Left and right

		Test.Add (GameObject.Find ("Hex_" + (x - 1) + "_" + y));
		Test.Add (GameObject.Find ("Hex_" + (x + 1) + "_"+y));
		//Test.Add (GameObject.Find ("Hex_" + (x + "_"+(y+1))));
		if (y % 2 != 0) 
		{
			Test.Add (GameObject.Find ("Hex_" + (x - 1) + "_"+(y+1)));
			Test.Add (GameObject.Find ("Hex_" + (x) + "_"+(y+1)));
			Test.Add (GameObject.Find ("Hex_" + (x - 1) + "_"+(y-1)));
			Test.Add (GameObject.Find ("Hex_" + (x) + "_"+(y-1)));
			Debug.Log ("its here");
		}
		else if (y % 2 == 0) 
		{
			Test.Add (GameObject.Find ("Hex_" + (x + 1) + "_"+(y+1)));
			Test.Add (GameObject.Find ("Hex_" + (x) + "_"+(y+1)));
			Test.Add (GameObject.Find ("Hex_" + (x + 1) + "_"+(y-1)));
			Test.Add (GameObject.Find ("Hex_" + (x) + "_"+(y-1)));
			Debug.Log ("its here");
		}
		//Test.Add (GameObject.Find ("Hex_" + (x - 1) + "_" + y));
		//Test.Add (GameObject.Find ("Hex_" + (x + 1) + "_"+y));

		//Array [0] = L.GetComponent<Hex>();


		//Array [1] = R.GetComponent<Hex>();
		Test.RemoveAll (item =>item==null);
		while (Test.Count!=0) 
		{
			T2.Add (Test [0].GetComponent<Hex> ());
			Test.RemoveAt (0);
			Debug.Log ("its here");

		}

		//test.RemoveAll (null);
		//Determine even and odd
		/*
		if (y % 2 != 0) 
		{
			GameObject UL=GameObject.Find ("Hex_" + (x - 1) + "_"+(y+1));
			GameObject UR=GameObject.Find ("Hex_" + (x + 1) + "_"+(y+1));
		}
		*/
		return T2.ToArray();
	}
	void Update ()
	{

	}


}

