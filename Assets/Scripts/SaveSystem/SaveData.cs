using System;

[Serializable]
public class SaveData
{
    public string playerName;
    public string selectedCharacter;

    public int currentMapLevel = 1;
    public int gold = 0;
    public int unspentSkillPoints = 0;

    public int healthLevel = 1;
    public int powerLevel = 1;
    public int attackSpeedLevel = 1;
    public int moveSpeedLevel = 1;

    // === BODY PARTS ===
    public string backPath = "";
    public string clothBodyPath = "";
    public string bodyArmorPath = "";
    public string hairPath = "";
    public string headPath = "";
    public string faceHairPath = "";

    // === EYES ===
    public string rightEyePath = "";
    public string leftEyePath = "";

    // === ARMS ===
    public string leftArmClothPath = "";
    public string leftShoulderArmorPath = "";
    public string weaponLeftPath = "";
    public string shieldLeftPath = "";

    public string rightArmClothPath = "";
    public string rightShoulderArmorPath = "";
    public string weaponRightPath = "";
    public string shieldRightPath = "";

    // === FEET ===
    public string rightFootPath = "";
    public string rightClothPath = "";
    public string leftFootPath = "";
    public string leftClothPath = "";
}
