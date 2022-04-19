using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    public string objectName;
    public ArrayList actionsToMake;
    public ArrayList actionsMade;
    public int score;
    //other attributes : carbon, ...


    public RecycleObject(string objectName , ArrayList actionsToMake, int score)
    {
        this.objectName = objectName;
        this.actionsToMake = actionsToMake;
        this.score = score;
        this.actionsMade = new ArrayList();
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
        return this.actionsToMake.Equals(this.actionsMade);
    }
}
