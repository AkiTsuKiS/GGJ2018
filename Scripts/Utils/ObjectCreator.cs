using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

static class ObjectCreator
{
	/*	Find and create Prefabs under parent GameObject
	 *	Prefabs assets MUST be put inside 'Assets/Resources' folder
	 */
	public static GameObject createPrefabs(string prefabs, GameObject parent, string name)
	{
		GameObject obj;
		try
		{
			obj = GameObject.Instantiate(Resources.Load(prefabs, typeof(GameObject)), parent.transform, false) as GameObject;
			obj.name = name;
		}
		catch (Exception e)
		{
			Log.E("[ObjectCreator] Fail to create prefabs : " + prefabs + " , error = " + e.ToString());
			obj = new GameObject(name);
			obj.transform.SetParent(parent.transform, false);
		}
		return obj;
	}
}
