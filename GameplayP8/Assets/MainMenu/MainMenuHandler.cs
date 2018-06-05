using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public bool hasData;
    [SerializeField] private Text resumeOrNewgameText;
    [Header("Animators")]
    [SerializeField] private Animator CameraAnimator;
    [SerializeField] private Animator MainButtonsAnimator;
    [SerializeField] private Animator CharacterSelectAnimator;
    [SerializeField] private Animator NewGameAnimator;
    [SerializeField] List<SelectHolderInfo> holder = new List<SelectHolderInfo>();
    public List<string> datas = new List<string>();

	void Start ()
    {
        datas.Add(PlayerPrefs.GetString("character0Data"));
        datas.Add(PlayerPrefs.GetString("character1Data"));
        datas.Add(PlayerPrefs.GetString("character2Data"));
        datas.Add(PlayerPrefs.GetString("character3Data"));
        datas.Add(PlayerPrefs.GetString("character4Data"));
        datas.Add(PlayerPrefs.GetString("character5Data"));

        for (int i = 0; i < datas.Count; i++)
        {
            holder[i].Init(datas[i]);
        }

        if (string.IsNullOrEmpty(datas[0]))
            hasData = false;
        else
            hasData = true;
        resumeOrNewgameText.text = hasData ? "Resume Game" : "New Game";
	}
	
    public void ResumeOrNewgame()
    {
        if (hasData)
            ResumeGame();
        else
            NewGame();
    }
    public void ResumeGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OpenCharacterSelect()
    {
        CameraAnimator.SetTrigger("Open");
        CharacterSelectAnimator.SetTrigger("Open");
        MainButtonsAnimator.SetTrigger("Close");
    }
    public void CloseCharacterSelect()
    {
        //add switched character
        CameraAnimator.SetTrigger("Close");
        CharacterSelectAnimator.SetTrigger("Close");
        MainButtonsAnimator.SetTrigger("Open");
    }

    public void NewGame(bool play = true)
    {
        MainButtonsAnimator.SetTrigger("Close");
        NewGameAnimator.SetTrigger("Open");
        if(play)
            CameraAnimator.SetTrigger("Newgame");
    }
    public void CloseNewGame()
    {
        CameraAnimator.SetTrigger("NewgameClose");
        NewGameAnimator.SetTrigger("Close");
        MainButtonsAnimator.SetTrigger("Open");

    }

    public void QuitGame()
    {
        string data = JsonUtility.ToJson(new CharacterData());
        PlayerPrefs.SetString("character1Data", "");
        Application.Quit();
    }

    public void LoadCharacterData(int index)
    {
        //to be made?
    }
}

[System.Serializable]
public struct CharacterData
{
    public ClassType type;
    public CharacterStats stats;
    public CharacterBelongings belongings;
    public CreatedData root;
}

[System.Serializable]
public struct CharacterStats
{
    public int level;
    public int physicalResist;
    public int magicResist;
    public int maxHealth;
    public int maxMana;
    public int strenght;
    public int dexterity;
    public int intelligence;
    public int recoveryPerSec;
    public int lifesteal;
}

[System.Serializable]
public struct CharacterBelongings
{
    public int money;
    public int skillpoints;
}

[System.Serializable]
public class CreatedData
{
    public string name = "";
    public bool hardcore = false;

    public CreatedData(string _name, bool _hardcore)
    {
        name = _name;
        hardcore = _hardcore;
    }
}

public enum ClassType
{
    wizard,
    berserk,
    assasin,
    hunter
};