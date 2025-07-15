using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public static CharacterFactory Instance;

    public PlayerCharacterData[] characterPool;

    private void Awake() => Instance = this;

    public GameObject SpawnPlayer(Vector3 spawnPos)
    {
        var id = SaveManager.Instance.currentData.selectedCharacter;
        var so = GetCharacterByID(id);

        var go = Instantiate(so.spumPrefab, spawnPos, Quaternion.identity);
        var spum = go.GetComponent<SpumController>();

        var partData = Resources.Load<CharacterPartData>($"CharacterPartData/{id}_Default");
        spum.ApplyParts(partData);

        return go;
    }

    private PlayerCharacterData GetCharacterByID(string id)
    {
        foreach (var so in characterPool)
            if (so.characterID == id) return so;
        return null;
    }
}
