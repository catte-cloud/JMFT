using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000065 RID: 101
public class TimerScript : MonoBehaviour
{
	// Token: 0x060001D1 RID: 465 RVA: 0x0000AA32 File Offset: 0x00008C32
	private void Start()
	{
		this.textBox.text = this.timeStart.ToString();
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0000AA4C File Offset: 0x00008C4C
	private void Update()
	{
		this.timeStart += Time.deltaTime;
		this.textBox.text = Mathf.Round(this.timeStart).ToString();
	}

	// Token: 0x040002E0 RID: 736
	public float timeStart;

	// Token: 0x040002E1 RID: 737
	public Text textBox;
}
