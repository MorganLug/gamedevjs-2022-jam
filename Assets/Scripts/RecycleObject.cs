using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    public string objectName;
    public List<string> actionsToMake;
    private List<string> actionsMade;
    public int score;
    //other attributes : carbon, ...

    private void Awake()
    {
        actionsMade = new List<string>();
    }
    public bool doAction(string action)
    {
        if (isValidAction(action))
        {
            //Animation lié à l'action
            return true;
        } else
        {
            //Animation erreur
            return false;
        }
    }

    public bool isValidAction(string action)
    {
        if (this.actionsMade.Count < this.actionsToMake.Count)
        {
            if (action == (string)this.actionsToMake[this.actionsMade.Count])
            {
                this.actionsMade.Add(action);
                return true;
            } else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }

    public bool objectTreated()
    {
        return actionsMade.Count == actionsToMake.Count;
    }
}
