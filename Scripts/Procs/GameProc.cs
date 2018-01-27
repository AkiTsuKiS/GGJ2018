using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProc : BaseProc
{
	protected GameObject _container;

	public override void enable()
	{
		initContainer();
		initLayer();
		start();
	}

	private void initContainer()
	{
		_container = new GameObject();
		_container.name = "GameProc";
		_container.transform.SetParent(GameObject.Find("Main").transform);
	}

	private void initLayer()
	{
		Instance.groundLayer = new GroundLayer("groundLayer", _container);
		Instance.borderLayer = new BorderLayer("borderLayer", _container);
		Instance.ballLayer = new BallLayer("ballLayer", _container);
		Instance.playerLayer = new PlayerLayer("playerLayer",_container);
		Instance.waveLayer = new WaveLayer("waveLayer",_container);
	}

	private void start()
	{
		
	}

	public override void disable()
	{
		//delete Container
		//delete Layer Instance
	}
}
