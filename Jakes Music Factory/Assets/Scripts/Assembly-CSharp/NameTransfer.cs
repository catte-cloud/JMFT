using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000019 RID: 25
public class NameTransfer : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000058 RID: 88 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x06000059 RID: 89 RVA: 0x0000297C File Offset: 0x00000B7C
	public void StoreName()
	{
		this.theName = this.inputField.GetComponent<Text>().text;
		this.textDisplay.GetComponent<Text>().text = "Hi, Welcome to JMFT " + this.theName + "!";
		PlayerPrefs.SetString("PlayerName", this.theName);
		SceneManager.LoadScene("MainMenu");
	}

	// Token: 0x0400003A RID: 58
	public string theName;

	// Token: 0x0400003B RID: 59
	public GameObject inputField;

	// Token: 0x0400003C RID: 60
	public GameObject textDisplay;

	// Token: 0x0400003D RID: 61
	public Text Nametext;
}
