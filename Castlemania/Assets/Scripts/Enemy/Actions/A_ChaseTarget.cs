using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ChaseTarget : BaseAction
{
    public GraphPathfinder pathfinder;
    public CharacterMovement movementScript;
    GraphManager graph;
    
    public void Start(){
        graph = GraphManager.instance;
    }
    override public void Invoke(){
        var desiredMovement = pathfinder.Pathfind(graph.GetCoordinates(transform.position));
        movementScript.Move(desiredMovement);
    }
}
