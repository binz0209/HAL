using UnityEngine;

public class CharacterPreviewSpawner : MonoBehaviour
{
    [Header("Prefab to spawn")]
    [SerializeField] private GameObject spumPrefab;

    [Header("Where to spawn preview")]
    [SerializeField] private Transform previewPoint;

    void Start()
    {
        if (spumPrefab == null)
        {
            Debug.LogError("SpumPrefab null!");
            return;
        }

        if (previewPoint == null)
        {
            Debug.LogError("PreviewPoint null!");
            return;
        }

        GameObject go = Instantiate(spumPrefab, previewPoint.position, Quaternion.identity, previewPoint);

        SpumController spum = go.GetComponentInChildren<SpumController>();

        if (spum == null)
        {
            Debug.LogError("Prefab not include SpumController!");
            return;
        }

        CharacterPartData partData = ScriptableObject.CreateInstance<CharacterPartData>();

        if (SaveManager.Instance != null && SaveManager.Instance.HasSave())
        {
            SaveData saved = SaveManager.Instance.Load();

            partData.backPath = saved.backPath;
            partData.clothBodyPath = saved.clothBodyPath;
            partData.bodyArmorPath = saved.bodyArmorPath;
            partData.hairPath = saved.hairPath;
            partData.headPath = saved.headPath;
            partData.faceHairPath = saved.faceHairPath;

            partData.rightEyePath = saved.rightEyePath;
            partData.leftEyePath = saved.leftEyePath;

            partData.leftArmClothPath = saved.leftArmClothPath;
            partData.leftShoulderArmorPath = saved.leftShoulderArmorPath;
            partData.weaponLeftPath = saved.weaponLeftPath;
            partData.shieldLeftPath = saved.shieldLeftPath;

            partData.rightArmClothPath = saved.rightArmClothPath;
            partData.rightShoulderArmorPath = saved.rightShoulderArmorPath;
            partData.weaponRightPath = saved.weaponRightPath;
            partData.shieldRightPath = saved.shieldRightPath;

            partData.rightFootPath = saved.rightFootPath;
            partData.rightClothPath = saved.rightClothPath;
            partData.leftFootPath = saved.leftFootPath;
            partData.leftClothPath = saved.leftClothPath;

            Debug.Log("Loaded PartData from Save!");
        }
        else
        {
            Debug.LogWarning("No Data!");
        }

        // 3️⃣ Apply PartData
        spum.ApplyParts(partData);
    }
}
