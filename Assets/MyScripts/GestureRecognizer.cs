using UnityEngine;
using System.Collections;

public class GestureRecognizer : MonoBehaviour
{
		public CharacterScript script;

		public Transform Head;
		public Transform Neck;
		public Transform Torso;
		public Transform Waist;

		public Transform LeftShoulder;
		public Transform LeftElbow;
		public Transform LeftWrist;

		public Transform RightShoulder;
		public Transform RightElbow;
		public Transform RightWrist;

		public Transform LeftHip;
		public Transform LeftKnee;
		public Transform LeftAnkle;

		public Transform RightHip;
		public Transform RightKnee;
		public Transform RightAnkle;
		
		//private float time;
		
		
		private float startTime;
		private float timeBetweenFlaps;
		
		private float maxTimeBetweenFlaps = 0.5f;
		
		private bool  done;
		
		private int flapState;
	
		void Update ()
		{
				Vector3 position = gameObject.transform.position;
		
				position.z = 0;
		
				if (position.y < 0)
						position.y = 0.0f;
						
				gameObject.transform.position = position;
		
				switch (flapState) {
				case(0):
						if (LeftWrist.position.y > LeftShoulder.position.y && RightWrist.position.y > RightShoulder.position.y) {
								++flapState;
								startTime = Time.time;
						}
						break;
				case(1):
						if (LeftWrist.position.y < LeftShoulder.position.y && RightWrist.position.y < RightShoulder.position.y) {
								flapState = 0;
								script.FlapReceived ();
						} else if (Time.time - startTime > maxTimeBetweenFlaps) {
								flapState = 0;
						}
						break;
				}					
		}
		/*
		void testPunch ()
		{
				if (!done && ((int)Time.time % 2) == 0) {
						done = true;
						script.leftChargeTime += Time.time;
						script.PunchReceived (LeftWrist, true);
				} else if (((int)Time.time % 2) == 1)
						done = false;
		}
	
		void CheckForCharge ()
		{
				if (GetDistanceSquared (RightWrist.transform, LeftWrist.transform) < chargeHandDistance) {
						if (!wasCharging) {
								wasCharging = true;
								script.StartedCharging ();
						}
						script.leftChargeTime += Time.deltaTime / chargeTimeDivider;
						script.rightChargeTime += Time.deltaTime / chargeTimeDivider;
				} else {
						if (wasCharging) {
								wasCharging = false;
								script.StoppedCharging ();
						}
				}
		}
	
		void CheckForPunch ()
		{
				float leftShoulderWristDistanceSquared = GetDistanceSquared (LeftShoulder.transform, LeftWrist.transform);
				float rightShoulderWristDistanceSquared = GetDistanceSquared (RightShoulder.transform, RightWrist.transform);
																						
				switch (punchStateLeft) {
				case(0):
						if (leftShoulderWristDistanceSquared < startArmDistance) {
								punchLeftStartTime = Time.time;
								++punchStateLeft;
						}
						break;
				case(1):
						if (Time.time - punchLeftStartTime <= maxPunchTime) {
								if (leftShoulderWristDistanceSquared < startArmDistance)
										punchLeftStartTime = Time.time;
								else if (leftShoulderWristDistanceSquared > stopArmDistance) {
										punchStateLeft = 0;
										script.PunchReceived (LeftWrist, true);
								}
						} else
								punchStateLeft = 0;
						break;
				}
		
				switch (punchStateRight) {
				case(0): 
						if (rightShoulderWristDistanceSquared < startArmDistance) {
								punchRightStartTime = Time.time;
								++punchStateRight;
						}
						break;
				case(1):
						if (Time.time - punchRightStartTime <= maxPunchTime) {
								if (rightShoulderWristDistanceSquared < startArmDistance)
										punchRightStartTime = Time.time;
								else if (rightShoulderWristDistanceSquared > stopArmDistance) {
										punchStateRight = 0;
										script.PunchReceived (RightWrist, false);
								}
						} else
								punchStateRight = 0;
						break;
				}
		}
	
		bool CheckForStomp (bool left)
		{
				float leftHipAnkleDistanceSquared = GetDistanceSquared (LeftHip.transform, LeftAnkle.transform);
				float rightHipAnkleDistanceSquared = GetDistanceSquared (RightHip.transform, RightAnkle.transform);
				if (left) {
						switch (stompStateLeft) {
						case(0):
								if (leftHipAnkleDistanceSquared < startLegDistance) {
										flapLeftStartTime = Time.time;
										++stompStateLeft;
								}
								break;
						case(1):
								if (Time.time - flapLeftStartTime <= maxStompTime) {
										if (leftHipAnkleDistanceSquared < startLegDistance)
												flapLeftStartTime = Time.time;
										else if (leftHipAnkleDistanceSquared > stopLegDistance) {
												stompStateLeft = 0;
												return true;
												;
										}
								} else
										stompStateLeft = 0;
								break;
						}
						return false;
				} else {
						switch (stompStateRight) {
						case(0):
								if (rightHipAnkleDistanceSquared < startLegDistance) {
										flapRightStartTime = Time.time;
										++stompStateRight;
								}
								break;
						case(1):
								if (Time.time - flapRightStartTime <= maxStompTime) {
										if (rightHipAnkleDistanceSquared < startLegDistance)
												flapRightStartTime = Time.time;
										else if (rightHipAnkleDistanceSquared > stopLegDistance) {
												stompStateRight = 0;
												return true;
										}
								} else
										stompStateRight = 0;
								break;
						}
						return false;
				}
		}
	*/
		float AngleBetweenTransformsGivenPivot (Transform a, Transform b, Transform pivot)
		{
				Vector3 side1 = a.position - pivot.position;
				Vector3 side2 = b.position - pivot.position;

				return Vector3.Angle (side1, side2);
		}
	
		float GetDistanceSquared (Transform a, Transform b)
		{
				Vector3 offset = a.position - b.position;
				return offset.sqrMagnitude;
		}
	
}