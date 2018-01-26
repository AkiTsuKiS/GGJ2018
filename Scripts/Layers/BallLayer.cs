using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLayer : BaseLayer
{
	public BallLayer(string name, GameObject parent) : base(name, parent)
	{
	}

	protected override void init()
	{
		// refer to Global.level, create Ball Object on the scene
	}
}
