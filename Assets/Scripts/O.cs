using UnityEngine;
using System.Collections;

public class O : MonoBehaviour 
{
	
	private PlayerController _playerStatus;

	[SerializeField]
	SpriteRenderer _renderer;

	[SerializeField]
	private Sprite _pcPlayer;

	private void Start()
	{
		_playerStatus=FindObjectOfType<PlayerController> ();
	}

	private void OnMouseDown()
	{
		if (_playerStatus.XO != PlayerController.PlyerSide.O)
		{
			_playerStatus.OChose ();
			_renderer.sprite = _pcPlayer;
		
			var Temp = GameObject.FindGameObjectsWithTag ("Empty");
			for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Empty").Length; i++) {
				Temp [i].name = i.ToString ();
				Temp [i].GetComponent<Collider2D> ().enabled = true;
			}
		}
	}

	void Update ()
	{
		if (_playerStatus.stat != PlayerController.StatusOfGame.ChuseSide) 
		{
			this.gameObject.GetComponent<Collider2D> ().enabled = false;
		}
	}
}
