using UnityEngine;
using System.Collections;

public class populate : MonoBehaviour 
{
	public GameObject hexPrefab;
	//Change these later this is to get a quick scalable map
	//Not unity space, hex space
	public int WidthTiles;
	public int HeightTiles;

	//offset for x coords
	float oddxoffset = -1.0f;

	//tile ratios 
	float xcoordMod = 2f;
	float deliveredx=1.0f;
	float ycoordMod = 1.5f;
	// Use this for initialization
	void Start () 
	{
		for (int x = 0; x < WidthTiles; x++) 
		{
			for (int y = 0; y < HeightTiles; y++) 
			{	
				deliveredx = (x * xcoordMod);
				if(y % 2 != 0)
				{
					deliveredx+=oddxoffset;
				}
				GameObject hex_go =(GameObject)Instantiate (hexPrefab, new Vector3 (deliveredx, 0, y*ycoordMod), Quaternion.identity);
				hex_go.name = "Hex_" + x + "_" + y;
				hex_go.GetComponent<Hex> ().x = x;
				hex_go.GetComponent<Hex> ().y = y;
				hex_go.transform.SetParent (this.transform);
				hex_go.isStatic = true;

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
