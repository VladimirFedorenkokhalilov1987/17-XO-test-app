using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardController : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private PlayerController playerStatus;

	void Start ()
	{
		playerStatus = FindObjectOfType<PlayerController> ();
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		playerStatus = FindObjectOfType<PlayerController> ();
	}

	private void OnMouseDown()
	{
		ChangeToXorO ();
		playerStatus.WinLooseCheck ();
	}
		
	public void ChangeToXorO ()
	{
		if (playerStatus.XO == PlayerController.PlyerSide.X)
		{
			spriteRenderer.sprite = playerStatus.X;
			playerStatus.stat = PlayerController.StatusOfGame.Wait;
			this.gameObject.tag = "X";
			playerStatus.PCMove ();

		}

		if (playerStatus.XO == PlayerController.PlyerSide.O) 
		{
			spriteRenderer.sprite = playerStatus.O;
			playerStatus.stat = PlayerController.StatusOfGame.Wait;
			this.gameObject.tag = "O";
			playerStatus.PCMove ();
		}
	}

	void Update()
	{
		if (this.gameObject.tag != "Empty")
			this.GetComponent<Collider2D> ().enabled = false;
	}
}