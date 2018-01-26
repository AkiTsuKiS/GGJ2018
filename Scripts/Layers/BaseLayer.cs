using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLayer
{
	protected GameObject _container;

	public BaseLayer(string name, GameObject parent)
	{
		_container = new GameObject();
		_container.name = name;
		_container.transform.SetParent(parent.transform,false);

		init();
	}

	protected virtual void init()
	{
	}
}
