using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.Experimental.Rendering;

public class KeyboardPikachuController : MonoBehaviour
{
  /*
    // [Range(0, 10)]
    public int ShockLight = 1;
    public GameObject _ElectricityParent;
    public float speed = 1;
    public GameObject _LightController;
    public Animator _Animator;
    public GameObject _PikachuModel;

    enum Direction  {Forward, Back, Left, Right };
    Direction PikachuDirection;
    void Start()
    {
        PikachuDirection = Direction.Forward;
    }

   
    float x;
    float z;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection!=Direction.Forward)
            {
                RotateFacing(Direction.Forward);
                PikachuDirection = Direction.Forward;
            }
            z += speed;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection != Direction.Back)
            {
                RotateFacing(Direction.Back);
                PikachuDirection = Direction.Back;
            }
            z -= speed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection != Direction.Left)
            {
                RotateFacing(Direction.Left);
                PikachuDirection = Direction.Left;
            }
            x -= speed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _Animator.SetBool("isMoving", true);
            if (PikachuDirection != Direction.Right)
            {
                RotateFacing(Direction.Right);
                PikachuDirection = Direction.Right;
            }
            x += speed;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseThunderbolt(true);
        }

        //back to zero
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(StandUp());
            _Animator.SetBool("isMoving", false);
            z = 0;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine(StandUp());
            _Animator.SetBool("isMoving", false);
            x = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            //here is where I would add the lighthouse anti-diminish function call
            UseThunderbolt(false);
        }

        transform.position += new Vector3(x, 0, z);
    }

    void UseThunderbolt(bool isPressed)
    {
        if(isPressed)
        {
            _ElectricityParent.SetActive(true);
            _LightController.GetComponent<LightHouse>().ChangeLightIntensity(ShockLight);
        }
        else
        {
            _ElectricityParent.SetActive(false);
        }
    }


    //in future iteration, consider lerping in a coroutine.
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
    */
}
