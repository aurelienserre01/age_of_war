using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 0)]

public class PlayerData : ScriptableObject
{
 	public Texture2D texture;
    public float speed;
    public float damage;
    public float health;
    public int attackPerSec;
    public int score;
    public int cost;
	public bool ally;
}