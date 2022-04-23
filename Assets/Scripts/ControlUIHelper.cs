using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUIHelper : MonoBehaviour
{
    private List<GameObject> controls = new List<GameObject>();
    private GameObject parent;

    public static Dictionary<string,string> controlDic = new Dictionary<string, string>();

    private void Awake()
    {
        //initialize dict
        controlDic.Add("grind", "left");
        controlDic.Add("melt", "up");
        controlDic.Add("clean", "right");
        controlDic.Add("disassemble", "down");
        controlDic.Add("discard", "backspace");

        parent = GetComponent<GameObject>();
    }

    public void deleteAllControls()
    {
        foreach (var control in controls)
        {
            Destroy(control);
        }
        controls.Clear();
    }

    public void addControls(List<string> actionsToMake)
    {
        for (int i = 0; i < actionsToMake.Count; i++)
        {
            addControl(actionsToMake[i], i);
        }
    }

    void addControl(string action, int position)
    {
        //GameObject go = Instantiate(Resources.Load<GameObject>("PreFabs/" + controlDic[action])); put it back, just tested with prefab

        //need to attach to the canvas, dunno how
        GameObject go = Instantiate(Resources.Load<GameObject>("PreFabs/empty"));
        go.transform.SetParent(parent.transform);
        go.transform.localScale.Set(50, 50, 0);
        switch (position)
        {
            case 0:
                go.transform.localPosition.Set(-236, 120, 0);
                break;
            default:
                break;  
            //other cases

        }
    }


}
