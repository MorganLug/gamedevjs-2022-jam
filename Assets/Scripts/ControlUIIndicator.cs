using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUIIndicator : MonoBehaviour
{
    public GameObject[] controls;

    private Dictionary<string,int> controlDic = new Dictionary<string, int>();

    void Start() 
    {
        controlDic.Add("grind", 0);
        controlDic.Add("melt", 1);
        controlDic.Add("clean", 2);
        controlDic.Add("disassemble", 3);
        controlDic.Add("discard", 4);
    }

    public void deleteAllControls()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Control")
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void addControls(List<string> actionsToMake)
    {
        int actionCount = actionsToMake.Count;
        for (int i = 0; i < actionCount; i++)
        {
            float xPosition = 50*(i - actionCount/2);
            addSingleControl(actionsToMake[i], xPosition);
        }
    }

    void addSingleControl(string action, float xPosition)
    {
        GameObject addedControl = Instantiate(controls[controlDic[action]]);
        addedControl.transform.SetParent(gameObject.transform);
        RectTransform addedControlRectTransform = addedControl.GetComponent<RectTransform>();
        addedControlRectTransform.localPosition = new Vector3(xPosition,-120,0);
    }
}
