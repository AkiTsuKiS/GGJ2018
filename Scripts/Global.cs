using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
	public enum GameStatu
	{
		Idle,
		Recording,
		Jumping,
		Explosion,
		Reward
	}

	public static int level = 1;
	public static GameStatu gameStatu; 
	public static float playerX;
	public static float playerY;
	public static float radio;
	public static int reward;
}