using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

	public GameObject empty;

	public Sprite startsprite;
	public Sprite Xsprite;
	public Sprite Osprite;

	private static int height = 3;
	private static int width = 3;

	void Start () 
	{
		GridCreate ();
	}


	private void GridCreate()
	{
		for (int i = 0; i < height; i++) 
		{
			for (int j = 0; j < width; j++) 
			{
				Instantiate (empty, new Vector3(2.5f-i*2.7f,1.3f-j*2.5f,0), Quaternion.identity);
				empty.tag = "Empty";
				empty.GetComponent<Collider2D> ().enabled = false;
			}
		}
	}
}
