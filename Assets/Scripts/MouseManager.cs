using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour 
{
	public Color def;
	bool press=false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		Ray ray =Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		Hex[] Tile;
		//check if button was released

		if (Physics.Raycast (ray, out hitInfo)) 
		{
			GameObject hovObj = hitInfo.collider.transform.parent.gameObject;
			GameObject hovObj2 = hitInfo.collider.transform.parent.parent.gameObject;


			//Look up card game tutorial of hovered tile
			//hovObj.transform.Translate (new Vector3 (0, 1, 0));
			if (Input.GetMouseButton(0)&&press==false)
			{
				press = true;
				FlipTile (hovObj);
				Tile=hovObj2.GetComponent<Hex>().GetN();
				FlipAdjacent (Tile);
			}
			if (Input.GetMouseButtonUp (0) ) 
			{
				press = false;
			}

		}
	}
	void FlipTile (GameObject Tile)
	{
		MeshRenderer mr= Tile.GetComponentInChildren<MeshRenderer> ();



		if (Tile.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("nothing")) 
		{
			Tile.GetComponent<Animator> ().enabled=true;
			Tile.GetComponent<Animator> ().SetTrigger ("Act");
			Tile.GetComponent<Animator> ().ResetTrigger ("React");
			mr.material.color = Color.white;
			Debug.Log ("Starts Here");
		}
		else if (Tile.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("n2")) 
		{
			Tile.GetComponent<Animator> ().enabled=true;
			Tile.GetComponent<Animator> ().SetTrigger ("React");
			Tile.GetComponent<Animator> ().ResetTrigger ("Act");
			mr.material.color = def;
			Debug.Log ("Goes Here");
		}
		//Tile.GetComponent<Animator> ().enabled=false;

	}
	void FlipAdjacent(Hex [] array)
	{
		GameObject A;
		for (int i = 0; i < array.Length; i++) 
		{
			A=GameObject.Find ("Hex_" + array[i].x + "_" + array[i].y).transform.GetChild(0).gameObject;
			//B=A.GetComponent ("Hex").gameObject;
			FlipTile (A);
		}
	}
}
