 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class TypeEffect : MonoBehaviour
{
    [SerializeField] TMP_Text tmpProTextIntro;
    [SerializeField] TMP_Text tmpProTextMain;
    [SerializeField] TMP_Text tmpProTextFail;
    [SerializeField] TMP_Text tmpProTextSuccess;
    string writer;
    [SerializeField] private Coroutine coroutine;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;
    [Space(10)][SerializeField] private bool startOnEnable = false;

    [Header("Collision-Based")]
    [SerializeField] private bool clearAtStart = false;
    [SerializeField] private bool startOnCollision = false;
    enum options { clear, complete }
    [SerializeField] options collisionExitOptions;


    [SerializeField] GameObject panelIntro;
    [SerializeField] GameObject panelMain;

    TMP_Text tmp_text;

    bool flag = true;

    bool flag_afterButton = false;

    bool flag_last_typewritting = true;

    int count;

    bool touchedLastFrame = false;

    string header;

    int touchCountScreen;

    int sceneCount;

    [SerializeField]
    GameObject neutral, happy, angry;

    [SerializeField]
    Button buttonA,buttonB, buttonC, buttonD;

    [SerializeField]
    GameObject buttonA_Right, buttonA_Wrong, buttonB_Right, buttonB_Wrong, buttonC_Right, buttonC_Wrong, buttonD_Right, buttonD_Wrong;

    [SerializeField]
    GameObject panelFail,panelSuccess;


    // Use this for initialization
    void Awake()
    {
        neutral.SetActive(false);
        angry.SetActive(false);
        happy.SetActive(false);

        panelIntro.SetActive(true);
        panelMain.SetActive(false);
        tmp_text = tmpProTextIntro;

        if (tmp_text != null)
        {
            writer = tmp_text.text;
        }
    }

    void Start()
    {
        if (!clearAtStart) return;

        if (tmp_text != null)
        {
            tmp_text.text = "";
        }

        sceneCount = SceneManager.GetActiveScene().buildIndex;

    }

    private void Update()
    {
        //Debug.Log(count);
        if (touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
        }
        else if (!touchedLastFrame && Input.touchCount > 0)
        {
            touchCountScreen += 1;
            if (count == 1 && tmp_text.text == writer)
            {
                panelIntro.SetActive(false);
                panelMain.SetActive(true);

                neutral.SetActive(true);

                tmp_text = tmpProTextMain;
                if (tmp_text != null)
                {
                    writer = tmp_text.text;
                    tmp_text.text = "";
                }
                StartTypewriter();
            }
            else if (count == 1 && tmp_text.text != writer)
            {
                tmp_text.text = writer;
                StopAllCoroutines();
            }
            else if (count == 2 && tmp_text.text == writer && flag)
            {
                tmp_text = tmpProTextMain;
                
                if (tmp_text != null)
                {
                    writer = tmp_text.text;
                    tmp_text.text = "";
                }
                StartTypewriter();
            }
            else if (count == 2 && tmp_text.text != writer)
            {
                tmp_text.text = writer;
                flag = false;
                StopAllCoroutines();
            }
            //else if (count == 2 &&  flag_afterButton)
            //{
            //    tmp_text = tmpProTextSuccess;

            //    if (tmp_text != null)
            //    {
            //        writer = tmp_text.text;
            //        tmp_text.text = "";
            //    }
            //    StartTypewriter();
            //}
            else if (count == 3 && tmp_text.text != writer)
            {
                tmp_text.text = writer;
                flag = false;
                StopAllCoroutines();
            }
            touchedLastFrame = true;

        }

        if (count == 2 && flag_afterButton && flag_last_typewritting)
        {
            tmp_text = tmpProTextSuccess;

            if (tmp_text != null)
            {
                writer = tmp_text.text;
                tmp_text.text = "";
            }
            delayBeforeStart = 1.6f;
            StartTypewriter();
            flag_last_typewritting = false;
        }

        if (count == 2 && angry.activeSelf && flag_last_typewritting)
        {
            tmp_text = tmpProTextFail;

            if (tmp_text != null)
            {
                writer = tmp_text.text;
                tmp_text.text = "";
            }
            delayBeforeStart = 1.6f;
            StartTypewriter();
            flag_last_typewritting = false;
        }
    }

    // B is right answer

    public void buttonA_tapped()
    {
        if (sceneCount == 2 || sceneCount == 5)
        {
            buttonA_Right.SetActive(true);
            flag_afterButton = true;

            neutral.SetActive(false);
            happy.SetActive(true);
        }
        else
        {
            buttonA_Wrong.SetActive(true);
            flag_afterButton = false;

            neutral.SetActive(false);
            angry.SetActive(true);
        }

        Invoke("flag_after_true", 0.9f);
    }

    public void buttonB_tapped()
    {
        if (sceneCount == 3 || sceneCount == 6)
        {
            buttonB_Right.SetActive(true);
            flag_afterButton = true;

            neutral.SetActive(false);
            happy.SetActive(true);
        }
        else
        {
            buttonB_Wrong.SetActive(true);
            flag_afterButton = false;

            neutral.SetActive(false);
            angry.SetActive(true);
        }

        Invoke("flag_after_true", 0.9f);
    }

    public void buttonC_tapped()
    {
        if (sceneCount == 4 || sceneCount == 9 || sceneCount == 7)
        {
            buttonC_Right.SetActive(true);
            flag_afterButton = true;

            neutral.SetActive(false);
            happy.SetActive(true);
        }
        else
        {
            buttonC_Wrong.SetActive(true);
            flag_afterButton = false;

            neutral.SetActive(false);
            angry.SetActive(true);
        }

        Invoke("flag_after_true", 0.9f);
    }

    public void buttonD_tapped()
    {
        if (sceneCount == 8 || sceneCount == 10)
        {
            buttonD_Right.SetActive(true);
            flag_afterButton = true;

            neutral.SetActive(false);
            happy.SetActive(true);
        }
        else
        {
            buttonD_Wrong.SetActive(true);
            flag_afterButton = false;

            neutral.SetActive(false);
            angry.SetActive(true);
        }

        Invoke("flag_after_true", 0.9f);
        
    }

    void flag_after_true()
    {
        panelMain.SetActive(false);
        Invoke("Final_Panel",0.7f);
    }

    void Final_Panel()
    {
        if (flag_afterButton)
        {
            panelSuccess.SetActive(true);
        }
        else
        {
            panelFail.SetActive(true);
        }
    }



    private void OnEnable()
    {
        //print("On Enable!");
        if (startOnEnable) StartTypewriter();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //print("Collision!");
        if (startOnCollision)
        {
            StartTypewriter();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (collisionExitOptions == options.complete)
        {

            if (tmp_text != null)
            {
                tmp_text.text = writer;
            }
        }
        // clear
        else
        {

            if (tmp_text != null)
            {
                tmp_text.text = "";
            }
        }

        StopAllCoroutines();
    }


    private void StartTypewriter()
    {
        StopAllCoroutines();

        if (tmp_text != null)
        {
            tmp_text.text = "";

            StartCoroutine("TypeWriterTMP");
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator TypeWriterTMP()
    {
        tmp_text.text = leadingCharBeforeDelay ? leadingChar : "";
        count++;

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (tmp_text.text.Length > 0)
            {
                tmp_text.text = tmp_text.text.Substring(0, tmp_text.text.Length - leadingChar.Length);
            }
            tmp_text.text += c;
            tmp_text.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            tmp_text.text = tmp_text.text.Substring(0, tmp_text.text.Length - leadingChar.Length);
        }
    }
}
