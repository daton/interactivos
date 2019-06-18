using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
   float rotarX;
	Rigidbody rb;
	CharacterController caracter;
	Vector3 vecMovimiento;


	public static int puntos = 0;


	void Start()
	{
		
		caracter = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		rotarX -= Input.GetAxis("Mouse Y");
		rotarX = Mathf.Clamp(rotarX, -45, 45);
		float deltaY = Input.GetAxis("Mouse X");

		float rotarY = transform.localEulerAngles.y + deltaY;
		transform.localEulerAngles = new Vector3(rotarX, rotarY, 0);

		//Programamos el movimiento

			float deltaX = Input.GetAxis("Horizontal") * 12 * Time.deltaTime;
			float deltaZ = Input.GetAxis("Vertical") * 12 * Time.deltaTime;


			vecMovimiento = new Vector3(deltaX, 0, deltaZ);
			vecMovimiento = Vector3.ClampMagnitude(vecMovimiento, 12);
			vecMovimiento = transform.TransformDirection(vecMovimiento);
			if (Input.GetButtonDown("Jump")) vecMovimiento.y = 3.5f;

		
		
		caracter.Move(vecMovimiento * 12 * Time.deltaTime);

	}
}
