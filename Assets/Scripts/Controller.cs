using System.ComponentModel.Design;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : Mover
{

    private float hDir = 0f;
    private float vDir = 0f;
    public bool isWorld = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            vDir++;
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            vDir--;

        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            //hDir++;
            base.rotate(180f * -30);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            hDir = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //hDir--;
            base.rotate(180f * 30);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            base.teleport();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += fastSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isWorld = true;
            hDir--;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isWorld = true;
            hDir++;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isWorld = true;
            vDir++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isWorld = true;
            vDir--;
        }
        


            if (hDir != 0f || vDir != 0f)
        {
            if (!isWorld)
            {
                base.moveWorld(hDir, vDir, moveSpeed);
            }
            else
            {
                base.move(hDir, vDir, moveSpeed);
            }

            isWorld = false;
        }
    }
}
