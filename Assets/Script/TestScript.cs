// ==============================
// @author Nimanji (Indies a.k.a)
// ==============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ==============================
// TestScript
// ==============================
namespace Assets.Scripts
{
    public class TestScript : MonoBehaviour
    {
        void Awake()
        {
            // 親となるGameObjectを取得
            GameObject parent_object = GameObject.Find("Character");
            // Resourcesディレクトリから画像を取得
            Object[] resources_images = Resources.LoadAll("", typeof(Sprite));
            // 取得した画像を1個ずつGameObjectとして生成する
            foreach (Sprite sprite in resources_images) {
                // GameObjectを読み込んだSprite名で生成
                GameObject instance_object = new GameObject(sprite.name);
                // GameObjectの親子関係、アンカー位置などを設定
                instance_object.transform.SetParent(parent_object.transform, false);
                instance_object.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                instance_object.GetComponent<RectTransform>().localScale = new Vector2(10, 10);
                // GameObjectにSpriteを適用し、アスペクト比と画像サイズの設定を行う
                instance_object.AddComponent<Image>().sprite = sprite;
                instance_object.GetComponent<Image>().preserveAspect = true;
                instance_object.GetComponent<Image>().SetNativeSize();
            }
        }
    }
}