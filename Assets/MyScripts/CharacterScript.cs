using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{
		private float forwardVelocity = 1.0f;
		float upForce = 300000.0f;

		//	private CoreLogic  CoreLogicScript;
//		public TextMesh statusTextBar;
	
		//private TextRenderScript script;
		private AudioSource source;
		
		void Start ()
		{
				source = gameObject.GetComponent<AudioSource> ();
		
				//CoreLogicScript = GameObject.Find ("CoreLogic").GetComponent<CoreLogic> ();
				//	statusTextBar = GameObject.Find ("StatusText").GetComponent<TextMesh> ();
				rigidbody.velocity = Vector3.left * forwardVelocity;
		}
	
		void Update ()
		{
				if (Input.GetKeyDown ("space"))
						FlapReceived ();
		}
	
		void OnTriggerEnter (Collider other)
		{
				//	statusTextBar.text = "YOU LOSE";
				source.Play ();
		}
	
		/*
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == invisibleWall) {
			//script.allowTextToDisappear = true;
			//script.DisplayText("Out of Bounds");
		}
	}
	*/
	
	
		public void FlapReceived ()
		{
				Debug.Log ("Flap Received");
				rigidbody.AddForce (Vector3.up * upForce);
		}
	
}
