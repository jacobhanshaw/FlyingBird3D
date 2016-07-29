using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour
{

		GameObject player;
		public GameObject wallPrefab;
		
		float wallLifetime = 50.0f;
		
		float lastWallLaunch;
		public float timeBetweenWalls = 8.0f;
	
		public float wallWidth = 30.0f;
		public float wallDepth = 4.0f;
	
		public float wallSpeed = 5.0f;
	
		public float wallStartDistance = 20.0f;
	
		const float overallHeight = 60.0f;
		
		const float minWallHeight = overallHeight * 0.30f;
		const float maxWallHeight = overallHeight * 0.70f;
	
		const float spaceBetweenWalls = overallHeight * 0.10f; //2 tall person
	
		//float minTimeBetweenWalls = 2.0f;
//	float maxTimeBetweenWalls = 5.0f;

		// Use this for initialization
		void Start ()
		{
				player = GameObject.Find ("Dana");
		}
	
		// Update is called once per frame
		void Update ()
		{
	
				//	if(timeBetweenWalls < 0)
				// timeBetweenWalls = Random.Range(minTimeBetweenWalls, maxTimeBetweenWalls);
		 
				if (Time.time - lastWallLaunch > timeBetweenWalls) {
						lastWallLaunch = Time.time;
						// 	timeBetweenWalls = -1.0f;
						
						GameObject lowerWall = (GameObject)Instantiate (wallPrefab);
						lowerWall.transform.localScale = new Vector3 (wallWidth, Random.Range (minWallHeight, maxWallHeight), wallDepth);
						float x = player.transform.position.x - wallStartDistance;
						float y = lowerWall.transform.localScale.y / 2.0f;
						float z = 0.0f;
						lowerWall.transform.position = new Vector3 (x, y, z);
						lowerWall.rigidbody.velocity = (Vector3.left * -wallSpeed);
			
						GameObject upperWall = (GameObject)Instantiate (wallPrefab, gameObject.transform.position, Quaternion.identity);
						float upperWallHeight = overallHeight - spaceBetweenWalls - lowerWall.transform.localScale.y;
						upperWall.transform.localScale = new Vector3 (wallWidth, upperWallHeight, wallDepth);
						y = lowerWall.transform.localScale.y + spaceBetweenWalls + upperWallHeight / 2.0f;
						upperWall.transform.position = new Vector3 (x, y, z);
						upperWall.rigidbody.velocity = (Vector3.left * -wallSpeed);
	
						Destroy (lowerWall, wallLifetime);
						Destroy (upperWall, wallLifetime);
				}
	
		
		
		}
}
