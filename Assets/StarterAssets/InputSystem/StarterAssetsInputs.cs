using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
       
        public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool next;
        public bool save;
        public bool interaction;
        public bool reset;


		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}


        public void OnSave(InputValue value)
        {
            SaveInput(value.isPressed);
        }

        public void OnNext(InputValue value)
        {
            NextInput(value.isPressed);
        }

        public void OnInteraction(InputValue value)
        {
            InteractionInput(value.isPressed);
        }

        public void OnReset(InputValue value)
        {
            ResetInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
            move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
           // Debug.Log("newJumpState"+newJumpState);
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
           // Debug.Log("newSprintState" + newSprintState);
            sprint = newSprintState;
		}

        public void NextInput(bool newNextState)
        {

            next = newNextState;
        }

        public void InteractionInput(bool newInteractionState)
        {

            interaction = newInteractionState;
        }

        public void ResetInput(bool newNextState)
        {

            reset = newNextState;
        }

        public void SaveInput(bool newSaveState)
        {
           // Debug.Log("newLoadState" + newSaveState);
            save = newSaveState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}