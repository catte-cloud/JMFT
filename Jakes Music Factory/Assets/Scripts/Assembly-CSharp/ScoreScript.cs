using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000051 RID: 81
public class ScoreScript : MonoBehaviour
{
	// Token: 0x06000175 RID: 373 RVA: 0x0000946C File Offset: 0x0000766C
	private void Start()
	{
		if (PlayerPrefs.GetString("CurrentMode") == "endless")
		{
			this.scoreText.SetActive(true);
			this.text.text = "Score:\n" + PlayerPrefs.GetInt("CurrentBooks") + " Notebooks";
		}
	}

	// Token: 0x06000176 RID: 374 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x04000269 RID: 617
	public GameObject scoreText;

	// Token: 0x0400026A RID: 618
	public Text text;
}
