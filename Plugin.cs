using System;
using BepInEx;
using UnityEngine;
using Utilla;

namespace GorillaTagModTemplateProject
{

	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		GameObject Sky;
		GameObject Monkey;
		float monkR;
		float monkG;
		float monkB;

		void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			Sky = GameObject.Find("/Level/newsky");
			Monkey = GameObject.Find("Global/Local VRRig/Local Gorilla Player/gorilla");

			var monkeyColor = Monkey.GetComponent<SkinnedMeshRenderer>().material.color;
			monkR = monkeyColor.r;
			monkG = monkeyColor.g;
			monkB = monkeyColor.b;

		}

		void Update()
		{
			if(Sky != enabled)
			{
				Sky.SetActive(this.enabled);
			}

			Sky.GetComponent<MeshRenderer>().material = null;
			Sky.GetComponent<MeshRenderer>().material.color = new Color(monkR, monkG, monkB);
		}
	}
}
