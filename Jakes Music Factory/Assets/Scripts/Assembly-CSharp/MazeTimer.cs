using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000014 RID: 20
public class MazeTimer : MonoBehaviour
{
	// Token: 0x06000048 RID: 72 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00002786 File Offset: 0x00000986
	private void FixedUpdate()
	{
		if (this.timertext.text == "150")
		{
			Application.Quit();
		}
	}

	// Token: 0x0400002F RID: 47
	public TimerScript timer;

	// Token: 0x04000030 RID: 48
	public GameObject baldi;

	// Token: 0x04000031 RID: 49
	public GameObject maze1;

	// Token: 0x04000032 RID: 50
	public GameObject maze2;

	// Token: 0x04000033 RID: 51
	public Text timertext;

	// Token: 0x04000034 RID: 52
	public AudioClip aud_scream;

	// Token: 0x04000035 RID: 53
	public GameControllerScript gc;
}
