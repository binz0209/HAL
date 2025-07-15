using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public PlayerCharacterData characterData;
    public CharacterSelectUI characterSelectUI;

    public void OnClick()
    {
        characterSelectUI.OnCharacterSelected(characterData);
        Debug.Log("Selected character: " + characterData.characterID);
    }
}
