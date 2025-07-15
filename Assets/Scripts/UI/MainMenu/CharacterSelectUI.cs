using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectUI : MonoBehaviour
{
    public PlayerCharacterData selectedCharacter;

    public void OnCharacterSelected(PlayerCharacterData character)
    {
        selectedCharacter = character;
        Debug.Log($"Selected character: {character.displayName}");
    }

    public void OnLetsGo()
    {
        if (selectedCharacter == null)
        {
            Debug.LogWarning("Choose a character first!");
            return;
        }

        SaveData data = new SaveData();
        data.playerName = SaveManager.Instance.pendingPlayerName;
        data.selectedCharacter = selectedCharacter.characterID;

        data.healthLevel = selectedCharacter.baseHealthLevel;
        data.powerLevel = selectedCharacter.basePowerLevel;
        data.attackSpeedLevel = selectedCharacter.baseAttackSpeedLevel;
        data.moveSpeedLevel = selectedCharacter.baseMoveSpeedLevel;

        var defaultPartData = selectedCharacter.defaultPartData;

        data.backPath = defaultPartData.backPath;
        data.clothBodyPath = defaultPartData.clothBodyPath;
        data.bodyArmorPath = defaultPartData.bodyArmorPath;
        data.hairPath = defaultPartData.hairPath;
        data.headPath = defaultPartData.headPath;
        data.faceHairPath = defaultPartData.faceHairPath;

        data.rightEyePath = defaultPartData.rightEyePath;
        data.leftEyePath = defaultPartData.leftEyePath;

        data.leftArmClothPath = defaultPartData.leftArmClothPath;
        data.leftShoulderArmorPath = defaultPartData.leftShoulderArmorPath;
        data.weaponLeftPath = defaultPartData.weaponLeftPath;
        data.shieldLeftPath = defaultPartData.shieldLeftPath;

        data.rightArmClothPath = defaultPartData.rightArmClothPath;
        data.rightShoulderArmorPath = defaultPartData.rightShoulderArmorPath;
        data.weaponRightPath = defaultPartData.weaponRightPath;
        data.shieldRightPath = defaultPartData.shieldRightPath;

        data.rightFootPath = defaultPartData.rightFootPath;
        data.rightClothPath = defaultPartData.rightClothPath;
        data.leftFootPath = defaultPartData.leftFootPath;
        data.leftClothPath = defaultPartData.leftClothPath;

        SaveManager.Instance.currentData = data;

        //SaveManager.Instance.Save();
        //Debug.Log("Game data saved.");

        LoadingSceneConfig.NextSceneName = "Scenes/Ingame/Map_1";
        SceneManager.LoadScene("Scenes/Loading/Loading");
        LoadingManager.Instance.StartOperation(LoadingSceneConfig.NextSceneName, LoadingManager.OperationMode.SaveGame);
    }
}
