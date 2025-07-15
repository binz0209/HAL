using System.IO;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpumController : MonoBehaviour
{
    // === Body ===
    public SpriteRenderer back, clothBody, bodyArmor, hair, head, faceHair;

    // === Eyes ===
    public SpriteRenderer rightEyeBack, rightEyeFront, leftEyeBack, leftEyeFront;

    // === Arms ===
    public SpriteRenderer leftArmCloth, leftShoulderArmor, weaponLeft, shieldLeft;
    public SpriteRenderer rightArmCloth ,rightShoulderArmor, weaponRight, shieldRight;

    // === Feet ===
    public SpriteRenderer rightFoot, rightCloth, leftFoot, leftCloth;

    private void Awake() => AutoFindParts();

    public void AutoFindParts()
    {
        var root = transform.Find("Root");
        back = root.Find("BodySet/P_Body/P_Back/Back").GetComponent<SpriteRenderer>();
        clothBody = root.Find("BodySet/P_Body/Body/P_ClothBody/ClothBody").GetComponent<SpriteRenderer>();
        bodyArmor = root.Find("BodySet/P_Body/Body/P_ArmorBody/BodyArmor").GetComponent<SpriteRenderer>();
        hair = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Hair/7_Hair").GetComponent<SpriteRenderer>();
        head = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Head/5_Head").GetComponent<SpriteRenderer>();
        faceHair = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Mustache/6_FaceHair").GetComponent<SpriteRenderer>();

        rightEyeBack = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Eye/P_REye/PivotBack/Back").GetComponent<SpriteRenderer>();
        rightEyeFront = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Eye/P_REye/PivotFront/Front").GetComponent<SpriteRenderer>();
        leftEyeBack = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Eye/P_LEye/PivotBack/Back").GetComponent<SpriteRenderer>();
        leftEyeFront = root.Find("BodySet/P_Body/HeadSet/P_Head/P_Eye/P_LEye/PivotFront/Front").GetComponent<SpriteRenderer>();

        leftArmCloth = root.Find("BodySet/P_Body/ArmSet/ArmL/P_LArm/P_Arm/20_L_Arm/P_LCArm/21_LCArm").GetComponent<SpriteRenderer>();
        leftShoulderArmor = root.Find("BodySet/P_Body/ArmSet/ArmL/P_LArm/P_Arm/20_L_Arm/P_Shoulder/25_L_Shoulder").GetComponent<SpriteRenderer>();
        weaponLeft = root.Find("BodySet/P_Body/ArmSet/ArmL/P_LArm/P_Weapon/L_Weapon").GetComponent<SpriteRenderer>();
        shieldLeft = root.Find("BodySet/P_Body/ArmSet/ArmL/P_LArm/P_Shield/L_Shield").GetComponent<SpriteRenderer>();

        rightArmCloth = root.Find("BodySet/P_Body/ArmSet/ArmR/P_RArm/P_Arm/-20_R_Arm/P_RCArm/-19_RCArm").GetComponent<SpriteRenderer>();
        rightShoulderArmor = root.Find("BodySet/P_Body/ArmSet/ArmR/P_RArm/P_Arm/-20_R_Arm/P_Shoulder/-15_R_Shoulder").GetComponent<SpriteRenderer>();
        weaponRight = root.Find("BodySet/P_Body/ArmSet/ArmR/P_RArm/P_Weapon/R_Weapon").GetComponent<SpriteRenderer>();
        shieldRight = root.Find("BodySet/P_Body/ArmSet/ArmR/P_RArm/P_Shield/R_Shield").GetComponent<SpriteRenderer>();

        rightFoot = root.Find("P_RFoot/_12R_Foot").GetComponent<SpriteRenderer>();
        rightCloth = root.Find("P_RFoot/P_RCloth/_11R_Cloth").GetComponent<SpriteRenderer>();
        leftFoot = root.Find("P_LFoot/_3L_Foot").GetComponent<SpriteRenderer>();
        leftCloth = root.Find("P_LFoot/P_LCloth/_2L_Cloth").GetComponent<SpriteRenderer>();
    }

    public void ApplyParts(CharacterPartData data)
    {
        back.sprite = LoadSprite(data.backPath);
        clothBody.sprite = LoadSubSprite(data.clothBodyPath, "Body");
        bodyArmor.sprite = LoadSubSprite(data.bodyArmorPath, "Body");
        hair.sprite = LoadSprite(data.hairPath);
        head.sprite = LoadSubSprite(data.headPath, "Head");
        faceHair.sprite = LoadSprite(data.faceHairPath);

        rightEyeBack.sprite = LoadSubSprite(data.rightEyePath, "Back");
        rightEyeFront.sprite = LoadSubSprite(data.rightEyePath, "Front");

        leftEyeBack.sprite = LoadSubSprite(data.leftEyePath, "Back");
        leftEyeFront.sprite = LoadSubSprite(data.leftEyePath, "Front");

        leftArmCloth.sprite = LoadSubSprite(data.leftArmClothPath, "Left");
        leftShoulderArmor.sprite = LoadSubSprite(data.leftShoulderArmorPath, "Left");
        weaponLeft.sprite = LoadSprite(data.weaponLeftPath);
        shieldLeft.sprite = LoadSprite(data.shieldLeftPath);

        rightArmCloth.sprite = LoadSubSprite(data.rightArmClothPath, "Right");
        rightShoulderArmor.sprite = LoadSubSprite(data.rightShoulderArmorPath, "Right");
        weaponRight.sprite = LoadSprite(data.weaponRightPath);
        shieldRight.sprite = LoadSprite(data.shieldRightPath);

        rightFoot.sprite = LoadSprite(data.rightFootPath);
        rightCloth.sprite = LoadSprite(data.rightClothPath);
        leftFoot.sprite = LoadSprite(data.leftFootPath);
        leftCloth.sprite = LoadSprite(data.leftClothPath);
    }

    public Sprite LoadSubSprite(string basePath, string subName)
    {
        string fullPath = Path.Combine("Addons/Legacy/0_Unit/0_Sprite", basePath);
        var allSprites = Resources.LoadAll<Sprite>(fullPath);
        if (allSprites == null || allSprites.Length == 0)
        {
            return null;
        }

        foreach (var s in allSprites)
        {
            if (s.name == subName)
            {
                return s;
            }
        }

        Debug.LogError($"❌ SubSprite '{subName}' không tồn tại trong {fullPath}");
        return null;
    }

    private Sprite LoadSprite(string relPath)
        => Resources.Load<Sprite>($"Addons/Legacy/0_Unit/0_Sprite/{relPath}");
}
