using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLayer : BaseLayer {
	public GroundLayer(string name, GameObject parent) : base(name, parent)
	{
	}

	protected override void init()
	{
		// refer to Global.level, create Ground object from Prefab to scene.
	}
}
