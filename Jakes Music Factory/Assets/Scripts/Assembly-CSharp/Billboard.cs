using System;
using UnityEngine;

// Token: 0x02000029 RID: 41
public class Billboard : MonoBehaviour
{
	// Token: 0x060000A7 RID: 167 RVA: 0x00003D08 File Offset: 0x00001F08
	private void Start()
	{
		this.m_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00003D20 File Offset: 0x00001F20
	private void LateUpdate()
	{
		base.transform.LookAt(base.transform.position + this.m_Camera.transform.rotation * Vector3.forward, this.m_Camera.transform.rotation * Vector3.up);
	}

	// Token: 0x040000C6 RID: 198
	private Camera m_Camera;
}
