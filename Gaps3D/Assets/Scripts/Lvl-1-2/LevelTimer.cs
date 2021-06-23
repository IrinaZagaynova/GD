using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelNumber;
    private float currentTime;
    private float startTime;
    private Text counterText;
    private bool isWin = false;
    static private bool flag = false;

    //static private bool pauseTimer = true;
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        //флаг добавила вроде для того, чтобы таймер работал только на уровнях, т.к.
        //местный таймер считает от начала запуска
        //+ устанавливаю false при перезапуске уровня (перехода на сцену нет, поэтому старт не сработает)
        flag = false;
    }
    
    public static void SetFlag(bool _flag)
    {
        flag = _flag;
    }

    //эта функция нужна для того, чтобы таймер останавливался при завершении уровня
    //т.к. при переходе на сцену есть задержка
    private void TimerStop()
    {
        float stopTime = Time.time - startTime;
        SetTime((int)stopTime/60, (int)stopTime % 60);
    }
    
    //просто вынесла повторяющийся код, здесь значения времени превращаются в текст
    void SetTime(float _minutes, float _seconds)
    {
        counterText.text = _minutes.ToString("00") + ":" + _seconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        //условие для того, чтобы таймер дальше не считал
        if (isWin)
        {
            return;
        }

        //получаем текущее время
        currentTime = Time.time;

		//стартовое время, т.е. когда мы начали считать время на уровне
		if (flag == false)
        {
            startTime = currentTime;
        }

        //записываем в текст время, которое представляет разницу между текущим и стартовым
        SetTime((int)(currentTime - startTime)/60, (int)(currentTime - startTime) % 60);

        flag = true;

        //тут просто условия прохождения по времени для разных уровней (для 1, 2 и еще 3-ий появился, лол)
        if (levelNumber <= 4)
        {
            //1 уровень
            if ((currentTime - startTime) % 60f >= 10)
            {
                counterText.color = new Color(255/255.0f, 121/255.0f, 0/255.0f, 255/255.0f);
            }
            if ((currentTime - startTime) % 60f >= 20)
            {
                 counterText.color = new Color(255/255.0f, 0/255.0f, 0/255.0f, 255/255.0f);
			}
            if ((currentTime - startTime) % 60f >= 30)
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (levelNumber > 4 && levelNumber <= 8)
        {
            //2 уровень
            if ((currentTime - startTime) % 60 >= 15)
            {
                counterText.color = new Color(255/255.0f, 121/255.0f, 0/255.0f, 255/255.0f);
            }
            if ((currentTime - startTime) % 60f >= 20)
            {
                counterText.color = new Color(255/255.0f, 0/255.0f, 0/255.0f, 255/255.0f);
            }
            if ((currentTime - startTime) % 60 >= 30)
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (levelNumber > 8 && levelNumber <= 12)
        {
                //3 уровень
            if ((currentTime - startTime) % 60 >= 20)
            {
                counterText.color = new Color(255/255.0f, 121/255.0f, 0/255.0f, 255/255.0f);
            }
            if ((currentTime - startTime) % 60f >= 30)
            {
                counterText.color = new Color(255/255.0f, 0/255.0f, 0/255.0f, 255/255.0f);
            }
            if ((currentTime - startTime) % 60 >= 40)
            {
                //SceneManager.LoadScene(SceneController.GetFail());
            }
        }
    }
}
