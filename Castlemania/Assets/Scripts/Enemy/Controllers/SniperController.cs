using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperController : MonoBehaviour
{
    public BaseAction aim;
    public int aimRepeats;
    public BaseAction flash;
    public int flashRepeats;
    public BaseAction shoot;
    public int shootRepeats;
    public int counter;
    public int state;

    public void Invoke() {
        ++counter;
        Act(state);
        if(counter == GetRepeats(state)){
            state = (state+1) % 3;
            counter = 0;
        }
    }

    private void Act(int index)
    {
        switch (index)
        {
            case 0:
                aim.Invoke();
                break;
            case 1:
                flash.Invoke();
                break;
            case 2:
                shoot.Invoke();
                break;
        }
    }
    
    private int GetRepeats(int index)
    {
        switch (index)
        {
            case 0:
                return aimRepeats;
            case 1:
                return flashRepeats;
            case 2:
                return shootRepeats;
        }
        return 0;
    }
}
