using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterPartData", menuName = "HAL/Character Part Data")]
public class CharacterPartData : ScriptableObject
{
    public string id;

    // === Body ===
    public string backPath;
    public string clothBodyPath;
    public string bodyArmorPath;
    public string hairPath;
    public string headPath;
    public string faceHairPath;

    // === Eyes ===
    public string rightEyePath;
    public string leftEyePath;

    // === Arms ===
    public string leftArmClothPath;
    public string leftShoulderArmorPath;
    public string weaponLeftPath;
    public string shieldLeftPath;

    public string rightArmClothPath;
    public string rightShoulderArmorPath;
    public string weaponRightPath;
    public string shieldRightPath;

    // === Feet ===
    public string rightFootPath;
    public string rightClothPath;
    public string leftFootPath;
    public string leftClothPath;
}
