using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class ThirdPersonCharacter : MonoBehaviour
	{

		public float movingTurnSpeed = 360;
		public float stationaryTurnSpeed = 180;
		public float abstandZumPlayer = 2;

        float turnAmount;
        float forwardAmount;

		Animator animatorZ1;

		void Start()
		{

			animatorZ1 = GetComponent<Animator>();
		}


		public void Move(Vector3 move, bool crouch, bool jump)
		{

			move = transform.InverseTransformDirection(move);
                turnAmount = Mathf.Atan2(move.x, move.z);
                forwardAmount = move.z;
                ApplyExtraTurnRotation();
                turnAmount = Mathf.Atan2(move.x, move.z);
                UpdateAnimator(move);
		}

		void ApplyExtraTurnRotation()
		{
			float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
                transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
		}


		void UpdateAnimator(Vector3 move) {
                if (forwardAmount == 0) {
						animatorZ1.SetBool ("isWalking", false);
                } else {
                        animatorZ1.SetBool ("isWalking", true);
                }
 
        }
	}
}
