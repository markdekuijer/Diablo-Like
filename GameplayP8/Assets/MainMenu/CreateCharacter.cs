using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour
{
    public int saveSlotIndex;
    [SerializeField] private InputField input;
    [SerializeField] private Toggle toggle;
    [SerializeField] private MainMenuHandler handler;

    public void Create()
    {
        CharacterData newData = new CharacterData();
        newData.root = new CreatedData(input.text, toggle.isOn);
        newData.stats = new CharacterStats();
        newData.belongings = new CharacterBelongings();
        print(saveSlotIndex);
        PlayerPrefs.SetString("character" + saveSlotIndex.ToString() + "Data", JsonUtility.ToJson(newData));
        print("load new game");
    }

    public void CloseSelectionOrNewGame()
    {
        if (string.IsNullOrEmpty(handler.datas[saveSlotIndex]))
        {
            handler.NewGame(false);
            //TODO camera extra anim maken. + anim not going back
        }
        else
            handler.CloseCharacterSelect();
    }
}
