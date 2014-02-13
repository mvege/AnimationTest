using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	public bool isAttacking = false;
	private bool isNotdoingSomething = true;

	// Update is called once per frame
	void Update ()
	{
		if (!animation.IsPlaying("Attack"))
		{
			//animation.Play ("Attack");
			isNotdoingSomething = false;
			//if (!animation.IsPlaying("Attack"))
			isAttacking = false;
		}
		else
		{
			if (Input.GetKey ("space"))
			{
				animation.Play ("Attack");
				isNotdoingSomething = false;
				isAttacking = true;
			}
		}
	}


	void FixedUpdate () {
		isNotdoingSomething = true;
		CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
		if (isAttacking)
		{
			animation.Play ("Attack");
			isNotdoingSomething = false;
			if (!animation.IsPlaying("Attack"))
				isAttacking = false;
		}
		else
		{
			if (Input.GetAxis ("Horizontal") != 0 | Input.GetAxis ("Vertical") != 0) {
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");

				// Move forwards/backwards
				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				//transform.Rotate (0, (moveVertical + moveHorizontal) * turnSpeed * Time.deltaTime, 0);
				controller.SimpleMove (movement * speed * Time.deltaTime);
				// Play animation
				animation.Play ("Walk");
				isNotdoingSomething = false;
			}
		}

		// If no key was pressed then do default animation
		if (isNotdoingSomething)
		{
			animation.Play ("idle");
		}
	}
}
