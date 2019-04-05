using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO.Ports;
using UnityEngine.Experimental.Rendering;

public class LightHouse : MonoBehaviour
{

	public float LightOn = 1;
	public float LightOff = 0;
	public float ShockLight = 1.2f;
	
	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600); //connect to the port
	public float duration = 1.0F;
	public Light lt;
	
	// Use this for initialization
	void Start ()
	{
		sp.Open();
		sp.ReadTimeout = 100; //not to freeze Unity
		//lt = GetComponent<Light>();
		
	}
	
	
	private int HouseLight; 
	
	// Update is called once per frame
	void Update ()
	{
	
		
		if (sp.IsOpen)
		{
			try
			{
//				print(sp.ReadByte());
				//HouseObject(sp.ReadByte());
				string test_line = sp.ReadLine();
				print(sp.ReadLine());
				string[] vec3 = test_line.Split(','); 
				
				HouseLight = int.Parse(vec3[3]);
				HouseObject(HouseLight);

			}
			catch (System.Exception)
			{
				
			}
		}
	}

	
	void HouseObject (int LightValue)
	{
		
		if (LightValue == 1)
		{
			lt.intensity = 0.8f;
			//lt.color = Color.white;;
		}
		
		if (LightValue == 0)
		{
			lt.intensity = 0.3f;
			//lt.color = Color.black;
		}

		
	}


}
