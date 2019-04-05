using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO.Ports;
using UnityEngine.Experimental.Rendering;

public class GoMove : MonoBehaviour
{

	public float speed;

	private float amountToMove;

	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600); //connect to the port
	
	// Use this for initialization
	void Start ()
	{
		sp.Open();
		sp.ReadTimeout = 1; //not to freeze Unity
	}
	
	// Update is called once per frame
	void Update ()
	{
		amountToMove = speed * Time.deltaTime;
		
		if (sp.IsOpen)
		{
			try
			{
				MoveObjet(sp.ReadByte());
				print(sp.ReadByte());
			}
			catch (System.Exception)
			{
				
			}
		}
	}

	void MoveObjet (int Direction)
	{
		if (Direction == 1)
		{
			transform.Translate(Vector3.left * amountToMove, Space.World);
		} 
		

		if (Direction == 2){
			transform.Translate(Vector3.right * amountToMove, Space.World);
		} 
		
		if (Direction == 3){
			transform.Translate(Vector3.up * amountToMove, Space.World);
		} 

		if (Direction == 4){
			transform.Translate(Vector3.down * amountToMove, Space.World);
		} 
		if (Direction == 5){
			transform.Translate(Vector3.down * amountToMove, Space.World);
		} 




	}
}
