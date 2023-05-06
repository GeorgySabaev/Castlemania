using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

[System.Serializable]
public class MoveTypeList
{
    public List<MoveType> list;

    public MoveTypeList()
    {
        list = new List<MoveType>();
    }

    public int GetHash()
    {
        int hashcode = 0;
        for (int i = 0; i < list.Count(); ++i)
        {
            hashcode <<= 4;
            hashcode |= ((int)list[i]);
        }
        return hashcode;
    }
}

[System.Serializable]
public class MoveToEventPair
{
    public MoveTypeList Moves;
    public UnityEvent Event;

    public MoveToEventPair(KeyValuePair<MoveTypeList, UnityEvent> kvp)
    {
        this.Moves = kvp.Key;
        this.Event = kvp.Value;
    }
}


public class ComboTracker : MonoBehaviour, ISerializationCallbackReceiver
{
    public List<MoveToEventPair> _actions = new List<MoveToEventPair>();
    public Dictionary<int, UnityEvent> Actions = new Dictionary<int, UnityEvent>();
    public int maxComboLength;
    public bool enteredCommand;
    public LinkedList<MoveType> actionLog = new LinkedList<MoveType>();

    public void OnBeforeSerialize() {}

    public void OnAfterDeserialize()
    {
        Actions = new Dictionary<int, UnityEvent>();

        for (int i = 0; i != _actions.Count; i++)
        {
            _actions[i].Moves.list.Reverse();
            Actions.Add(_actions[i].Moves.GetHash(), _actions[i].Event);
            _actions[i].Moves.list.Reverse();
        }
    }
    public void Start(){
       Clock.instance.BeatResolves.AddListener(ResolveMove);
    }

    public void MakeMove(MoveType type)
    {
        if(enteredCommand){
            return;
        }
        enteredCommand = true;
        actionLog.AddFirst(type);
        if (actionLog.Count > maxComboLength){
            actionLog.RemoveLast();
        }
    }

    public void ResolveMove() {
        Debug.Log(1);
        if(!enteredCommand){
            MakeMove(MoveType.idle);
        }
        enteredCommand = false;
        var tmp = new MoveTypeList();
        UnityEvent action = new UnityEvent();
        foreach (var move in actionLog){
            tmp.list.Add(move);
            if(Actions.ContainsKey(tmp.GetHash())){
                Debug.Log(tmp.GetHash().ToString() + "|" + tmp.list.Count());
                action = Actions[tmp.GetHash()];
            }
        }
        action?.Invoke();
    }
}
