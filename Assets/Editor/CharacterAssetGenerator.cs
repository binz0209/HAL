#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CharacterAssetGenerator
{
    [MenuItem("HAL/Create Default Characters")]
    public static void CreateDefaultCharacters()
    {
        string folderPath = "Assets/Data/Characters";

        if (!AssetDatabase.IsValidFolder("Assets/Data"))
            AssetDatabase.CreateFolder("Assets", "Data");
        if (!AssetDatabase.IsValidFolder(folderPath))
            AssetDatabase.CreateFolder("Assets/Data", "Characters");

        CreateCharacter("TULINH", "TuLinh", 1, 2, 3, 4);
        CreateCharacter("XHUM", "XHum", 4, 4, 1, 1);
        CreateCharacter("VANAN", "VanAn", 2, 2, 2, 2);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("✅ Character assets created in Assets/Data/Characters/");
    }

    private static void CreateCharacter(string id, string name,
                                        int hp, int power, int atkSpeed, int moveSpeed)
    {
        var asset = ScriptableObject.CreateInstance<PlayerCharacterData>();
        asset.characterID = id;
        asset.displayName = name;

        asset.baseHealthLevel = hp;
        asset.basePowerLevel = power;
        asset.baseAttackSpeedLevel = atkSpeed;
        asset.baseMoveSpeedLevel = moveSpeed;

        string path = $"Assets/Data/Characters/{id}.asset";
        AssetDatabase.CreateAsset(asset, path);
    }
}
#endif
