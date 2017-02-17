using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour 
{

	private bool EndGameXWin=false;
	private bool EndGameOWin=false;

	public Sprite X;
	public Sprite O;
	public Sprite None;

	private SpriteRenderer spriteRenderer;

	public enum StatusOfGame
	{
		Play,
		Wait,
		ChuseSide
	}

	public enum PlyerSide
	{
		None,
		X,
		O
	}

	public enum PCSide
	{
		None,
		X,
		O
	}


	public PlyerSide XO;
	public PCSide PCXO;
	public StatusOfGame stat;

	[SerializeField]
	private GameObject Xwin;
	[SerializeField]
	private GameObject Owin;
	[SerializeField]
	private GameObject Draw;


	void Awake ()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		stat = StatusOfGame.ChuseSide;
		XO = PlyerSide.None;
	}
		
	public void XChose () 
	{
		if (XO == PlyerSide.None) 
		{
			XO = PlyerSide.X;
			PCXO = PCSide.O;
			stat = StatusOfGame.Play;
		}
	}
		
	public void WinLooseCheck()
	{
		/////////////////X Win
		if (GameObject.Find ("0").tag == "X" && GameObject.Find ("1").tag == "X" && GameObject.Find ("2").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("3").tag == "X" && GameObject.Find ("4").tag == "X" && GameObject.Find ("5").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("6").tag == "X" && GameObject.Find ("7").tag == "X" && GameObject.Find ("8").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("0").tag == "X" && GameObject.Find ("3").tag == "X" && GameObject.Find ("6").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("1").tag == "X" && GameObject.Find ("4").tag == "X" && GameObject.Find ("7").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("2").tag == "X" && GameObject.Find ("5").tag == "X" && GameObject.Find ("8").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("0").tag == "X" && GameObject.Find ("4").tag == "X" && GameObject.Find ("8").tag == "X") 
		{
			EndGameXWin = true;
		} 

		if (GameObject.Find ("2").tag == "X" && GameObject.Find ("4").tag == "X" && GameObject.Find ("6").tag == "X") 
		{
			EndGameXWin = true;
		}

		//////////////////////O Win
		if (GameObject.Find ("0").tag == "O" && GameObject.Find ("1").tag == "O" && GameObject.Find ("2").tag == "O") 
		{
			EndGameOWin = true;
		} 

		if (GameObject.Find ("3").tag == "O" && GameObject.Find ("4").tag == "O" && GameObject.Find ("5").tag == "O") 
		{
			EndGameOWin = true;
		} 

		if (GameObject.Find ("6").tag == "O" && GameObject.Find ("7").tag == "O" && GameObject.Find ("8").tag == "O") 
		{
			EndGameOWin = true;
		} 

		if (GameObject.Find ("0").tag == "O" && GameObject.Find ("3").tag == "O" && GameObject.Find ("6").tag == "O") 
		{
			EndGameOWin = true;
		} 

		if (GameObject.Find ("1").tag == "O" && GameObject.Find ("4").tag == "O" && GameObject.Find ("7").tag == "O") 
		{
			EndGameOWin = true;
		} 
		if (GameObject.Find ("2").tag == "O" && GameObject.Find ("5").tag == "O" && GameObject.Find ("8").tag == "O") 
		{
			EndGameOWin = true;
		} 

		if (GameObject.Find ("0").tag == "O" && GameObject.Find ("4").tag == "O" && GameObject.Find ("8").tag == "O")
		{
			EndGameOWin = true;
		} 

		if (GameObject.Find ("2").tag == "O" && GameObject.Find ("4").tag == "O" && GameObject.Find ("6").tag == "O")
		{
			EndGameOWin = true;
		}
	}

	public void OChose () 
	{
		if (XO == PlyerSide.None) 
		{
			XO = PlyerSide.O;
			PCXO = PCSide.X;
			stat = StatusOfGame.Play;
		}
	}

	public void NoneChose () 
	{
		XO = PlyerSide.None;
		PCXO = PCSide.None;
		spriteRenderer.sprite = null;
		stat = StatusOfGame.ChuseSide;
	}
		
	public void ReloadLevel()
	{
		SceneManager.LoadScene (0);
	}

	public void PCMove()
	{
		if (stat == StatusOfGame.Wait && GameObject.FindGameObjectsWithTag("Empty").Length>0)
		{
			if(PCXO == PCSide.X) {
				var Temp = GameObject.FindGameObjectsWithTag ("Empty") [(Random.Range (0, GameObject.FindGameObjectsWithTag ("Empty").Length))].GetComponent<SpriteRenderer> ();
					Temp.sprite = X;
				Temp.tag = "X";
				Temp.GetComponent<Collider2D> ().enabled = false;
				stat = StatusOfGame.Wait;
			}

			if(PCXO == PCSide.O) 
			{
				var Temp = GameObject.FindGameObjectsWithTag ("Empty")[(Random.Range(0,GameObject.FindGameObjectsWithTag ("Empty").Length))].GetComponent<SpriteRenderer> ();
				Temp.sprite = O;
				Temp.tag = "O";
				Temp.GetComponent<Collider2D> ().enabled = false;
				stat = StatusOfGame.Wait;
			}
		}
	}

	private void Update()
	{
		if (GameObject.FindGameObjectsWithTag ("Empty").Length == 0 && !EndGameOWin && !EndGameXWin)
		{
			Draw.SetActive(true);
		}

		if(EndGameOWin)
		{
			Owin.SetActive (true);
			var Temp = GameObject.FindGameObjectsWithTag ("Empty");
			for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Empty").Length; i++) 
			{
				Temp [i].GetComponent<Collider2D> ().enabled = false;
			}
		}

		if(EndGameXWin) 
		{
			Xwin.SetActive (true);
			var Temp = GameObject.FindGameObjectsWithTag ("Empty");
			for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Empty").Length; i++) {
				Temp [i].GetComponent<Collider2D> ().enabled = false;
			}
		}
	}
}