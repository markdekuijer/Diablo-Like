using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHolderInfo : MonoBehaviour
{
    public bool exists;
    [SerializeField] Image image; //Nog niet in gebruik
    private Text name;
    private CharacterData newData;
    [SerializeField] private int index;
    [SerializeField] private Text buttonText;
    [SerializeField] private CreateCharacter createMenu;

    public void Init(string data)
    {
        name = GetComponentInChildren<Text>();
        if (!string.IsNullOrEmpty(data))
        {
            newData = JsonUtility.FromJson<CharacterData>(data);
            name.text = newData.root.name;
            exists = true;
        }
        else
        {
            exists = false;
            name.text = "No Character";
        }
	}

    public void ShowCharacter()
    {
        createMenu.saveSlotIndex = index;
        if (exists)
        {
            name.name = newData.root.name;
            buttonText.text = "Select Character";
        }
        else
        {
            buttonText.text = "New Character";
            print("No character");
        }
    }
}
