using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000003 RID: 3
public class AudioButtonScript : MonoBehaviour
{
	// Token: 0x06000006 RID: 6 RVA: 0x0000208C File Offset: 0x0000028C
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.Play));
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000020B6 File Offset: 0x000002B6
	private void Play()
	{
		this.Notesource.PlayOneShot(this.note);
	}

	// Token: 0x04000002 RID: 2
	private Button button;

	// Token: 0x04000003 RID: 3
	public GameObject screen;

	// Token: 0x04000004 RID: 4
	public AudioSource Notesource;

	// Token: 0x04000005 RID: 5
	public AudioClip note;
}
