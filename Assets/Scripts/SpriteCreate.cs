using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCreate : MonoBehaviour
{
   public Texture2D texture;
       private Sprite mySprite;
       private SpriteRenderer sr;
   
       void Awake()
       {
           sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
           sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
   
           transform.position = new Vector3(1.5f, 1.5f, 0.0f);
       }
   
       void Start()
       {
           mySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
       }
   
       void OnGUI()
       {
           if (GUI.Button(new Rect(10, 10, 100, 30), "Add sprite"))
           {
               sr.sprite = mySprite;
           }
       }
}
