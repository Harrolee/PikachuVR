using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Media;
using UnityEngine.Experimental.Rendering;

public class PikachuController : MonoBehaviour
{
   //[Range(0, 10)]   //feel free to mess with this
    public int ShockLight = 1;
    public GameObject _ElectricityParent;
    public float speed = 1;
    public GameObject _LightController;
    public Animator _Animator;
    public GameObject _PikachuModel;
    //public AudioSource ThunderSound;


    SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600); //connect to the port


    enum Direction  {Forward, Back, Left, Right };
    Direction PikachuDirection;


    void Start()
    {
        PikachuDirection = Direction.Forward;
        sp.Open();
        sp.ReadTimeout = 10; //not to freeze Unity
    }
    

    int JoystickDirection;
    
    float x;
    float z;
    private int X;
    private int Y; 
    private int click_button;
    private int photo; 
    
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                //JoystickDirection = sp.ReadByte();
                string test_line = sp.ReadLine();
                
                print(sp.ReadLine());
                string[] vec3 = test_line.Split(','); 
                X = int.Parse(vec3[0]);
                Y = int.Parse(vec3[1]);
                click_button = int.Parse(vec3[2]);
             //   photo = int.Parse(vec3[3]);
            }
            catch (System.Exception)
            {

            }
        }

        if (X == 1)
        {
            Debug.Log ("1");
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection!=Direction.Forward)
            {
                RotateFacing(Direction.Forward);
                PikachuDirection = Direction.Forward;
            }
            z += speed;
        }
        else if (X == 2)
        {

            Debug.Log ("2");
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection != Direction.Back)
            {
                RotateFacing(Direction.Back);
                PikachuDirection = Direction.Back;
            }
            z -= speed;
        }
        else if (Y == 1)
        {
            Debug.Log ("3");
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection != Direction.Left)
            {
                RotateFacing(Direction.Left);
                PikachuDirection = Direction.Left;
            }
            x -= speed;
        }
        else if (Y == 2)
        {
            Debug.Log ("4");
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection != Direction.Right)
            {
                RotateFacing(Direction.Right);
                PikachuDirection = Direction.Right;
            }
            x += speed;
        }

        if(click_button == 0)
        {
            UseThunderbolt(true);
            
        }
        else if (click_button == 1)
        {
            UseThunderbolt(false);

        }

        //back to zero
        if ((X == 0) && (Y == 0))
        {
            StartCoroutine(StandUp());
            _Animator.SetBool("isMoving", false);
            z = 0;
            x = 0;
        }

        transform.position += new Vector3(x, 0, z);
    }

   
    void UseThunderbolt(bool isPressed)
    {
        if(isPressed)
        {
        //    ThunderSound.Play();
            _ElectricityParent.SetActive(true);
         //   _LightController.GetComponent<LightHouse>().FireLight(true);
           // StartCoroutine(PlayThunderSound());
        }
        else
        {
           // ThunderSound.Stop();
            _ElectricityParent.SetActive(false);
         //   _LightController.GetComponent<LightHouse>().FireLight(false);
        }
    }

    void RotateFacing(Direction nextDirection)
    {
        if (nextDirection == Direction.Forward)
        {
            _PikachuModel.transform.rotation = Quaternion.identity;
        }
        if (nextDirection == Direction.Back)
        {
            _PikachuModel.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (nextDirection == Direction.Left)
        {
            _PikachuModel.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (nextDirection == Direction.Right)
        {
            _PikachuModel.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
    
    IEnumerator StandUp()
    {
        yield return new WaitForSeconds(1);
        if(!Input.anyKeyDown || !Input.anyKeyDown && Input.GetKeyDown(KeyCode.Space))
        {
            _Animator.SetBool("wasInput", true);
        }
        yield return new WaitForSeconds(1);
        _Animator.SetBool("wasInput", false);
    }

    private bool canPlayThunder = true;

  //  IEnumerator PlayThunderSound()
  //  {
    //    if (canPlayThunder)
    //    {
       //     ThunderSound.Play();
      //      canPlayThunder = false;
      //     yield return new WaitForSeconds(ThunderSound.clip.length);
        //    ThunderSound.Stop();
      // }
      //  else
       // {
        //    Debug.Log("Waiting for Finish");
       // }
   // }





}
    
    

