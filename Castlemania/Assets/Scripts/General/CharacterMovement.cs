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
        var direction = new Vector2(-1, 0);
        SetFlipped(direction);
        if (graph.ConnectedLeft(graph.GetCoordinates(transform.position)))
        {
            Move(direction);
        }
    }

    public void MoveRight()
    {
        var direction = new Vector2(1, 0);
        SetFlipped(direction);
        if (graph.ConnectedRight(graph.GetCoordinates(transform.position)))
        {
            Move(direction);
        }
    }

    public void MoveUp()
    {
        var direction = new Vector2(0, 1);
        SetFlipped(direction);
        if (graph.ConnectedUp(graph.GetCoordinates(transform.position)))
        {
            Move(direction);
        }
    }

    public void MoveDown()
    {
        var direction = new Vector2(0, -1);
        SetFlipped(direction);
        if (graph.ConnectedDown(graph.GetCoordinates(transform.position)))
        {
            Move(direction);
        }
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
        transform.position = graph.tilemap.CellToWorld(graph.GetCoordinates(transform.position)); // snap to grid
    }

    private void SetFlipped(Vector2 direction)
    {
        if (direction.x > 0)
        {
            anim?.SetBool("flipped", false);
        }
        else if (direction.x < 0)
        {
            anim?.SetBool("flipped", true);
        }
    }
}
