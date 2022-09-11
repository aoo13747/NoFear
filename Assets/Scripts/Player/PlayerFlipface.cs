using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipface : MonoBehaviour
{
    public Animator animator;     
    Vector2 moveinput;
    
    private void Update()
    {
        //Debug.Log(moveinput.x);
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
        //animator.SetFloat("Speed", Mathf.Abs(moveinput.x));
        /////////////////////////////////////////////////////
        if (moveinput.x == 0 && moveinput.y == 0)
        {
            //animator.SetTrigger("Stop");
            //animator.SetBool("Stopit", true);
            animator.SetBool("Moveit", false);
            //  ChangeAnimationState(Idle);
        }
        if(moveinput.x !=0 || moveinput.y != 0)
        {
            //animator.SetTrigger("Move");
            animator.SetBool("Moveit", true);
            //ChangeAnimationState(Moveing);
        }
    }
    bool faceright = true;
    public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);        
    }   
}
