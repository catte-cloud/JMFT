using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000054 RID: 84
public class StartButton : MonoBehaviour
{
	// Token: 0x0600017F RID: 383 RVA: 0x0000954D File Offset: 0x0000774D
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.StartGame));
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00009578 File Offset: 0x00007778
	private void StartGame()
	{
		if (base.name == "StoryButton")
		{
			PlayerPrefs.SetString("CurrentMode", "story");
		}
		else if (base.name == "DoubleButton")
		{
			PlayerPrefs.SetString("CurrentMode", "double");
		}
		else if (base.name == "EndlessButton")
		{
			PlayerPrefs.SetString("CurrentMode", "story");
		}
		else if (base.name == "PranksterButton")
		{
			PlayerPrefs.SetString("CurrentMode", "pie");
		}
		SceneManager.LoadScene("Factory");
	}

	// Token: 0x0400026F RID: 623
	private Button button;
}
