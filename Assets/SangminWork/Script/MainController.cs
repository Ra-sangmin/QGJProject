﻿using System.Collections;
using System.Collections.Generic;
using GodJunie.QGJ2020;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public StoryStateEnum storyStateEnum = StoryStateEnum.Start;
    [SerializeField] Text msgText;
    [SerializeField] List<Text> selectTextList = new List<Text>();

    MainActData mainActData = null;
    int mainSelectId;
    SubActData subActData = null;
    int subSelectId;
    FinalActData finalActData = null;
    int finalSelectId;
    string endingId;

    ParamResultData raramResultData = null;

    string startMsg = string.Empty;

    int dayCnt = 1;
    int maxDayCnt = 14;

    public enum PlayerStatusEnum
    {
        Hungry,
        Clean,
        Mental,
        Cost
    }

    /// <summary> 만복도 </summary>
    int hungry = 100;
    int addHungry = 0;
    int beforeHungry = 100;

    /// <summary> 청결함 </summary>
    int clean = 100;
    int addClean = 0;
    int beforeClean = 100;

    /// <summary> 정신력 </summary>
    int mental = 100;
    int addMental = 0;
    int beforeMental = 100;

    /// <summary> 소지금 </summary>
    int cost = 10000;
    int addCost = 0;
    int beforeCost = 10000;

    List<string> selectStrList = new List<string>();
    List<MainActData> mainActList = new List<MainActData>();

    [SerializeField] Text selectResultText;
    [SerializeField] Text resultText;

    [SerializeField] Text endingText;

    [SerializeField] Button dirextFinalBtn;

    bool isAM = false;

    bool endingFadeOn = true;
    public CanvasGroup canvasGroup;
    public Text endingTouchText;

    // Start is called before the first frame update
    void Start()
    {
        StoryReset();
    }

    void Init()
    {
        dayCnt = 1;

        hungry = DataManager.Instance.ParameterDataList[0].Value;
        clean = DataManager.Instance.ParameterDataList[1].Value;
        mental = DataManager.Instance.ParameterDataList[2].Value;
        cost = DataManager.Instance.ParameterDataList[3].Value;
    }

    void StoryReset()
    {
        selectStrList = new List<string>();

        if (storyStateEnum == StoryStateEnum.Start)
        {
            mainActList = new List<MainActData>();

            var mainList = DataManager.Instance.mainActDataList;

            while (true)
            {
                int ranIndex = Random.Range(0, mainList.Count);

                mainActData = DataManager.Instance.GetMainData(ranIndex);

                if (mainActData != null && !mainActList.Contains(mainActData))
                {
                    mainActList.Add(mainActData);
                }

                if (mainActList.Count > 3)
                {    
                    break;
                }
            }

            foreach (var mainAct in mainActList)
            {
                selectStrList.Add(mainAct.Name);
            }
        }
        else if (storyStateEnum == StoryStateEnum.Main)
        {
            mainActData = DataManager.Instance.GetMainData(mainSelectId);

            Debug.LogWarning("mainActData.Id = "+mainActData.Id);

            List<int> intList = new List<int>();

            while (true)
            {
                int ranIndex = Random.Range(0, mainActData.Nextacts.Length);

                int targetID = mainActData.Nextacts[ranIndex];

                if (intList.Contains(targetID) == false)
                {
                    intList.Add(targetID);
                }

                if (intList.Count > 3 || intList.Count == mainActData.Nextacts.Length)
                {
                    break;
                }
            }

            foreach (var id in intList)
            {
                SubActData data = DataManager.Instance.GetSubData(id);

                if (data.Name != string.Empty)
                {
                    selectStrList.Add(data.Name);
                }
            }
        }
        else if (storyStateEnum == StoryStateEnum.Sub)
        {
            subActData = DataManager.Instance.GetSubData(subSelectId);

            if (subActData.Nextacts.Length == 1)
            {
                selectResultText.gameObject.SetActive(false);
                dirextFinalBtn.gameObject.SetActive(true);
            }
            else
            {
                List<int> intList = new List<int>();

                while (true)
                {
                    int ranIndex = Random.Range(0, subActData.Nextacts.Length);

                    int targetID = subActData.Nextacts[ranIndex];

                    if (intList.Contains(targetID) == false)
                    {
                        intList.Add(targetID);
                    }

                    if (intList.Count > 3 || intList.Count == subActData.Nextacts.Length)
                    {
                        break;
                    }
                }

                foreach (var id in intList)
                {
                    FinalActData data = DataManager.Instance.GetFinalData(id);

                    if (data.Name != string.Empty)
                    {
                        selectStrList.Add(data.Name);
                    }
                    
                }
            }

        }
        else if (storyStateEnum == StoryStateEnum.Final)
        {
            dirextFinalBtn.gameObject.SetActive(false);

            finalActData = DataManager.Instance.GetFinalData(finalSelectId);

            raramResultData = DataManager.Instance.GetParamResultData(finalActData.Nextacts);
            //finalActData.

            beforeHungry = hungry;
            addHungry = raramResultData.Hungry;
            hungry += addHungry;

            beforeClean = clean;
            addClean = raramResultData.Clean;
            clean += addClean;

            beforeMental = mental;
            addMental = raramResultData.Mental;
            mental += addMental;

            beforeCost = cost;
            addCost = raramResultData.Cost;
            cost += addCost;
        }

        SetText();
    }

    void SetText()
    {
        if (storyStateEnum == StoryStateEnum.Start)
        {
            isAM = !isAM;
            string amPmStr = isAM ? "오전" : "오후";

            msgText.text = string.Format(  "오늘은 전염병으로 자가격리를 실시한 지 {0}일째." +
                                           "\n나의 상태는 " +
                                           "\n배부름: {1} %" +
                                           "\n감염도: {2} %" +
                                           "\n멘탈 : {3} %" +
                                           "\n가진돈 : {4}원이다." +
                                           "\n\n아직 {5}이다.오늘은 이런 것들을 할 수 있을 것 같다.",
                                           dayCnt, hungry, clean, mental, cost, amPmStr);
            selectResultText.gameObject.SetActive(true);
            resultText.gameObject.SetActive(false);
            dirextFinalBtn.gameObject.SetActive(false);

        }
        if (storyStateEnum == StoryStateEnum.Main)
        {
            msgText.text = mainActData.Description;
        }
        else if (storyStateEnum == StoryStateEnum.Sub)
        {
            msgText.text = subActData.Description;
        }
        else if (storyStateEnum == StoryStateEnum.Final)
        {
            msgText.text = finalActData.Description;

            selectResultText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            resultText.text = string.Format("{0}\n{1}\n{2}\n{3}",
                                             GetResultStatusText(PlayerStatusEnum.Hungry),
                                             GetResultStatusText(PlayerStatusEnum.Clean),
                                             GetResultStatusText(PlayerStatusEnum.Mental),
                                             GetResultStatusText(PlayerStatusEnum.Cost));
        }

        foreach (var selectText in selectTextList)
        {
            selectText.gameObject.SetActive(false);
        }

        for (int i = 0; i < selectStrList.Count; i++)
        {
            if (i >= selectTextList.Count)
            {
                break;
            }

            selectTextList[i].text = string.Format("{0}. {1}",(i+1),selectStrList[i]);
            selectTextList[i].gameObject.SetActive(true);
        }
    }

    public void SelectTextOn(int state)
    {
        if (storyStateEnum ==  StoryStateEnum.Start)
        {
            mainSelectId = mainActList[state].Id;
            storyStateEnum = StoryStateEnum.Main;
        }
        else if (storyStateEnum == StoryStateEnum.Main)
        {
            subSelectId = mainActData.Nextacts[state];
            storyStateEnum = StoryStateEnum.Sub;
        }
        else if (storyStateEnum == StoryStateEnum.Sub)
        {
            finalSelectId = subActData.Nextacts[state];
            storyStateEnum = StoryStateEnum.Final;
        }
        else if (storyStateEnum == StoryStateEnum.Ending)
        {
            storyStateEnum = StoryStateEnum.Start;

            canvasGroup.gameObject.SetActive(false);

            Init();
        }

        StoryReset();

    }

    public string GetResultStatusText(PlayerStatusEnum playerStatusEnum)
    {
        string headStr = string.Empty;

        int currentValue = 0;
        int addValue = 0;
        int beforeValue = 0;

        switch (playerStatusEnum)
        {
            case PlayerStatusEnum.Hungry:
                headStr = "배부름이";
                currentValue = hungry;
                beforeValue = beforeHungry;
                addValue = addHungry;
                break;
            case PlayerStatusEnum.Clean:
                headStr = "감염도가";
                currentValue = clean;
                beforeValue = beforeClean;
                addValue = addClean;
                break;
            case PlayerStatusEnum.Mental:
                headStr = "멘탈이";
                currentValue = mental;
                beforeValue = beforeMental;
                addValue = addMental;
                break;
            case PlayerStatusEnum.Cost:
                headStr = "가진돈이";
                currentValue = cost;
                beforeValue = beforeCost;
                addValue = addCost;
                break;
        }

        string middleStr = string.Empty;
        if (playerStatusEnum == PlayerStatusEnum.Cost)
        {
            middleStr =  string.Format("{0}원", Mathf.Abs(addValue));
        }
        else
        {
            middleStr = string.Format("{0:f0} %", Mathf.Abs(addValue));
        }

        string tailStr = addValue > 0 ? "<color=teal>증가</color>했다." : "<color=red>감소</color>했다.";

        return string.Format("{0} {1} {2}", headStr, middleStr, tailStr);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDayOn()
    {
        if (storyStateEnum != StoryStateEnum.Final)
            return;

        EndingCheck();
    }

    void EndingCheck()
    {
        if (clean <= 0)
        {
            EndingOn("ed00");
        }
        else if (hungry <= 0)
        {
            EndingOn("ed01");
        }
        else if (mental <= 0)
        {
            EndingOn("ed02");
        }
        else if (dayCnt > 14)
        {
            int ranState = Random.Range(4, 12);
            endingId = string.Format("ed{D2}", ranState);
            EndingOn(endingId);
        }
        else
        {
            dayCnt++;
            storyStateEnum = StoryStateEnum.Start;
            StoryReset();
        }

    }

    public void EndingOn(string endingId)
    {
        this.endingId = endingId;
        storyStateEnum = StoryStateEnum.Ending;

        selectResultText.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        foreach (var selectText in selectTextList)
        {
            selectText.gameObject.SetActive(false);
        }


        OP_EDData data = DataManager.Instance.GetOP_EDData(endingId);
        msgText.text = data.Desc;

        StartCoroutine(EndingDoing());
        
    }


    IEnumerator EndingDoing()
    {
        canvasGroup.gameObject.SetActive(true);
        endingFadeOn = true;
        canvasGroup.alpha = 0;
        endingTouchText.gameObject.SetActive(false);

        yield return new WaitForSeconds(10f);

        while (true)
        {
            canvasGroup.alpha += 0.005f;

            yield return new WaitForSeconds(0.01f);

            if (canvasGroup.alpha == 1)
            {
                break;
            }
        }
        endingFadeOn = false;
        endingTouchText.gameObject.SetActive(true);

    }

    public void ReStartOn()
    {        
        if (endingFadeOn)
            return;

        SelectTextOn(0);
    }

}
