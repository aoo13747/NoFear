using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipface : MonoBehaviour
{
    public Animator animator;
    Vector2 moveinput;
    
    private void FixedUpdate()
    {        
        moveinput.x = Input.GetAxis("Vertical");
        moveinput.y = Input.GetAxis("Horizontal");
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouse.x < transform.position.x && faceright && PauseMenu.isPause == false)
        {
            Flip();
        }
        else if (mouse.x > transform.position.x && !faceright && PauseMenu.isPause == false)
        {
            Flip();
        }
        
        if (moveinput.x == 0 && moveinput.y == 0)
        {
           
            animator.SetBool("Moveit", false);
            
        }
        if(moveinput.x !=0 || moveinput.y != 0)
        {
            
            animator.SetBool("Moveit", true);
            
        }
    }
    bool faceright = true;
    public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);        
    }   
}
