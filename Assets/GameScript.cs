using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    private float initDate;
    public float timeAllowed;
    public TMPro.TextMeshProUGUI timerText;
    public GameObject currentItem;
    
    // Start is called before the first frame update
    void Start()
    {
        initDate = Time.time;
        currentItem = Instantiate(RecycleObjectFactory.generateObject());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAllowed > Time.time - initDate)
        {
            timerText.text = formatTime(timeAllowed - (Time.time - initDate));
            Debug.Log(currentItem.GetComponent<RecycleObject>().objectName);
        } else
        {
            //deactivate game
        }
    }

    private string formatTime(float time)
    {
        int seconds = (int)time;
        int tenth = (int)(time * 100 - seconds * 100);
        return seconds.ToString() + "." + tenth.ToString() + "sec";
    }
}
