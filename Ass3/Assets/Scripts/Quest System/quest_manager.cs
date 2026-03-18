using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class quest_manager : MonoBehaviour
{
    public List<quest_so> quests;
    public Dictionary<quest_so, quest_data> questLibrary = new();
    public static quest_manager instance;
    public event Action<quest_data> onQuestUpdate;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeQuestLibrary();
    }

    public void InitializeQuestLibrary()
    {
        foreach(quest_so q in quests)
        {
            quest_data tmp = new quest_data(q);
            tmp.onQuestUpdated += UpdateQuest;
            tmp.onQuestCompleted += CompleteQuest;
            questLibrary.Add(q, tmp);
        }
    }

    public void UpdateQuest(quest_data questData)
    {
        questLibrary[questData.Config] = questData;
        onQuestUpdate?.Invoke(questData);
    }

    public void CompleteQuest(quest_data questData)
    {
        questLibrary[questData.Config].isComplete = true;
    }

    public void ActivateQuest(quest_so quest)
    {
        questLibrary[quest].isActive = true;
        Debug.Log("starting quest: " + quest.questName);
        goal_manager.instance.TrackQuest(questLibrary[quest]);
    }
}
