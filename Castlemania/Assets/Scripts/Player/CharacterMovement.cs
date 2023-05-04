using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator anim;
    public void MoveLeft()
    {
        Move(new Vector2(-1, 0));
    }

    public void MoveRight()
    {
        Move(new Vector2(1, 0));
    }

    public void MoveUp()
    {
        Move(new Vector2(0, 1));
    }

    public void MoveDown()
    {
        Move(new Vector2(0, -1));
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
        if (direction.x > 0) {
            anim.SetBool("flipped", false);
        }
        else if (direction.x < 0) {
            anim.SetBool("flipped", true);
        }
    }
}
