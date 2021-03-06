using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

    private float initDate;
    public float timeAllowed;

    private int score;

    private TMPro.TextMeshProUGUI timerText;
    private TMPro.TextMeshProUGUI scoreText;
    private TMPro.TextMeshProUGUI objectName;

    private GameObject currentGameObject;
    private RecycleObject currentRecycleObject;

    private PlayerInput inputSystem;


    private ControlUIIndicator controlUIIndicator;


    private void Awake()
    {
        awakeInputSystem();


        controlUIIndicator = GetComponent<ControlUIIndicator>();

        timerText = gameObject.transform.Find("Timer/TimerValue").GetComponent<TMPro.TextMeshProUGUI>();
        scoreText = gameObject.transform.Find("Score/ScoreValue").GetComponent<TMPro.TextMeshProUGUI>();
        objectName = gameObject.transform.Find("ObjectPlaceholder/ObjectName").GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Start()
    {
        initDate = Time.time;
        score = 0;

        instantiateRecycleObject();

    }

    void Update()
    {
        if (timeAllowed > Time.time - initDate)
        {
            
            updateTimerAndScore();
        }
        else
        {
            EndGameManager.setScore(score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    //Input system
    private void awakeInputSystem()
    {
        inputSystem = GetComponent<PlayerInput>();
        inputSystem.onActionTriggered += InputSystem_onActionTriggered;
    }

    private void InputSystem_onActionTriggered(InputAction.CallbackContext obj)
    {
        //TODO : Add animations for feedback for user, even if error (can be done in RecycleObject Script
        if (obj.performed)
        {
            if (currentRecycleObject.doAction(obj.action.name))
            {
                if (currentRecycleObject.objectTreated())
                {
                    score += currentRecycleObject.score;
                    SoundEffectsManager.playSuccessObjectSound();
                    instantiateRecycleObject();
                } else
                {
                    SoundEffectsManager.playSuccessActionSound();
                }
            } else
            {
                //Instantiate the new object after error animation has finished playing
                SoundEffectsManager.playErrorSound();
                instantiateRecycleObject();
            }
        }
    }

    //GameObject logic
    private void instantiateRecycleObject()
    {
        if (currentGameObject != null)
        {
            currentRecycleObject = null;
            Destroy(currentGameObject);
        }
        currentGameObject = Instantiate(RecycleObjectFactory.generateObject());
        currentRecycleObject = currentGameObject.GetComponent<RecycleObject>();
        giveNameObject();


        // controlUIHelper.addControls(currentRecycleObject.actionsToMake);
        controlUIIndicator.deleteAllControls();
        controlUIIndicator.addControls(currentRecycleObject.actionsToMake);


    }

    private void giveNameObject()
    {
        objectName.text = currentRecycleObject.objectName;
    }

    //utils
    private string formatTime(float time)
    {
        int seconds = (int)time;
        int tenth = (int)(time * 100 - seconds * 100);
        return seconds.ToString() + "." + tenth.ToString() + "sec";
    }

    private void updateTimerAndScore()
    {
        timerText.text = formatTime(timeAllowed - (Time.time - initDate));
        scoreText.text = score.ToString();
    }
}
