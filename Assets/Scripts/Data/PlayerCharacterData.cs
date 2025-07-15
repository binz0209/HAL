using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "HAL/Character")]
public class PlayerCharacterData : ScriptableObject
{
    [Header("Core Info")]
    public string characterID;
    public string displayName;

    [Header("Prefab Reference")]
    public GameObject spumPrefab;

    [Header("Base Stats")]
    public int baseHealthLevel = 1;
    public int basePowerLevel = 1;
    public int baseAttackSpeedLevel = 1;
    public int baseMoveSpeedLevel = 1;

    [Header("Appearance Template")]
    public CharacterPartData defaultPartData;
}
