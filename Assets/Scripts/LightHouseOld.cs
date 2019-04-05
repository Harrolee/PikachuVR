using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO.Ports;
using UnityEngine.Experimental.Rendering;

public class LightHouseOld : MonoBehaviour
{

	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600); //connect to the port
    public Light _Light;
	public float duration = 1.0F;
    [Range(0.1f, 10.0f)]
    public float IntensityBuffer = 1;
    [Range(0.1f, 1f)]
    public float DimRate = .5f;

    void Start ()
	{
		sp.Open();
		sp.ReadTimeout = 1; //not to freeze Unity
	}

    float currIntensity;
	void Update ()
	{
            currIntensity = Time.deltaTime * DimRate;
            _Light.intensity -= currIntensity;

        if (sp.IsOpen)
		{
			try
			{
				print("serial port byte value is: " + sp.ReadByte()); //What are the possible values for this?
                ChangeLightIntensity(sp.ReadByte());
            }
			catch (System.Exception)
			{
				
			}
		}

        print(" "+_Light.intensity);
    }
    
    //Hey Caleb, if the photoresistor constantly sends values in, sent intensity will be the same as the intensity for the room.
    // You will need to calibrate this when testing.
    //Try adjusting the "IntensityBuffer" in the inspector to get the right values. It's called a buffer, but it can also amplify.
    //below 1.0 will decrease the value sent by the photoresistor. above 1.0 will increase.
    public void ChangeLightIntensity(int sentIntensity)
    {
        _Light.intensity = sentIntensity * IntensityBuffer;
        print(""+ sentIntensity +":buffer->" + IntensityBuffer);
    }


}
