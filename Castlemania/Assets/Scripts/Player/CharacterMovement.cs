using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator anim;
    private GraphManager graph;

    public void Start()
    {
        graph = GraphManager.instance;
    }

    public void MoveLeft()
    {
        if (graph.ConnectedLeft(graph.GetCoordinates(transform.position)))
        {
            Move(new Vector2(-1, 0));
        }
    }

    public void MoveRight()
    {
        if (graph.ConnectedRight(graph.GetCoordinates(transform.position)))
        {
            Move(new Vector2(1, 0));
        }
    }

    public void MoveUp()
    {
        if (graph.ConnectedUp(graph.GetCoordinates(transform.position)))
        {
            Move(new Vector2(0, 1));
        }
    }

    public void MoveDown()
    {
        if (graph.ConnectedDown(graph.GetCoordinates(transform.position)))
        {
            Move(new Vector2(0, -1));
        }
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
        if (direction.x > 0)
        {
            anim.SetBool("flipped", false);
        }
        else if (direction.x < 0)
        {
            anim.SetBool("flipped", true);
        }
    }
}
