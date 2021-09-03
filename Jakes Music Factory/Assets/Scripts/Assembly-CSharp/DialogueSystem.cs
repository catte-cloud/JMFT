using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005D RID: 93
public class DialogueSystem : MonoBehaviour
{
	// Token: 0x060001AB RID: 427 RVA: 0x0000A15D File Offset: 0x0000835D
	private void Start()
	{
		this.dialogueText.text = "";
	}

	// Token: 0x060001AC RID: 428 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
	}

	// Token: 0x060001AD RID: 429 RVA: 0x0000A16F File Offset: 0x0000836F
	public void EnterRangeOfNPC()
	{
		this.outOfRange = false;
		this.dialogueGUI.SetActive(true);
		if (this.dialogueActive)
		{
			this.dialogueGUI.SetActive(false);
		}
	}

	// Token: 0x060001AE RID: 430 RVA: 0x0000A198 File Offset: 0x00008398
	public void NPCName()
	{
		this.outOfRange = false;
		this.dialogueBoxGUI.gameObject.SetActive(true);
		this.nameText.text = this.Names;
		if (Input.GetKeyDown(KeyCode.F) && !this.dialogueActive)
		{
			this.dialogueActive = true;
			base.StartCoroutine(this.StartDialogue());
		}
		this.StartDialogue();
	}

	// Token: 0x060001AF RID: 431 RVA: 0x0000A1FA File Offset: 0x000083FA
	private IEnumerator StartDialogue()
	{
		if (!this.outOfRange)
		{
			int dialogueLength = this.dialogueLines.Length;
			int currentDialogueIndex = 0;
			while (currentDialogueIndex < dialogueLength || !this.letterIsMultiplied)
			{
				if (!this.letterIsMultiplied)
				{
					this.letterIsMultiplied = true;
					string[] array = this.dialogueLines;
					int num = currentDialogueIndex;
					currentDialogueIndex = num + 1;
					base.StartCoroutine(this.DisplayString(array[num]));
					if (currentDialogueIndex >= dialogueLength)
					{
						this.dialogueEnded = true;
					}
				}
				yield return 0;
			}
			while (!Input.GetKeyDown(this.DialogueInput) || this.dialogueEnded)
			{
				yield return 0;
			}
			this.dialogueEnded = false;
			this.dialogueActive = false;
			this.DropDialogue();
		}
		yield break;
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x0000A209 File Offset: 0x00008409
	private IEnumerator DisplayString(string stringToDisplay)
	{
		if (!this.outOfRange)
		{
			int stringLength = stringToDisplay.Length;
			int currentCharacterIndex = 0;
			this.dialogueText.text = "";
			while (currentCharacterIndex < stringLength)
			{
				Text text = this.dialogueText;
				text.text += stringToDisplay[currentCharacterIndex].ToString();
				int num = currentCharacterIndex;
				currentCharacterIndex = num + 1;
				if (currentCharacterIndex >= stringLength)
				{
					this.dialogueEnded = false;
					break;
				}
				if (Input.GetKey(this.DialogueInput))
				{
					yield return new WaitForSeconds(this.letterDelay * this.letterMultiplier);
					if (this.audioClip)
					{
						this.audioSource.PlayOneShot(this.audioClip, 0.5f);
					}
				}
				else
				{
					yield return new WaitForSeconds(this.letterDelay);
					if (this.audioClip)
					{
						this.audioSource.PlayOneShot(this.audioClip, 0.5f);
					}
				}
			}
			while (!Input.GetKeyDown(this.DialogueInput))
			{
				yield return 0;
			}
			this.dialogueEnded = false;
			this.letterIsMultiplied = false;
			this.dialogueText.text = "";
		}
		yield break;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0000A21F File Offset: 0x0000841F
	public void DropDialogue()
	{
		this.dialogueGUI.SetActive(false);
		this.dialogueBoxGUI.gameObject.SetActive(false);
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x0000A240 File Offset: 0x00008440
	public void OutOfRange()
	{
		this.outOfRange = true;
		if (this.outOfRange)
		{
			this.letterIsMultiplied = false;
			this.dialogueActive = false;
			base.StopAllCoroutines();
			this.dialogueGUI.SetActive(false);
			this.dialogueBoxGUI.gameObject.SetActive(false);
		}
	}

	// Token: 0x040002B7 RID: 695
	public Text nameText;

	// Token: 0x040002B8 RID: 696
	public Text dialogueText;

	// Token: 0x040002B9 RID: 697
	public GameObject dialogueGUI;

	// Token: 0x040002BA RID: 698
	public Transform dialogueBoxGUI;

	// Token: 0x040002BB RID: 699
	public float letterDelay = 0.1f;

	// Token: 0x040002BC RID: 700
	public float letterMultiplier = 0.5f;

	// Token: 0x040002BD RID: 701
	public KeyCode DialogueInput = KeyCode.F;

	// Token: 0x040002BE RID: 702
	public string Names;

	// Token: 0x040002BF RID: 703
	public string[] dialogueLines;

	// Token: 0x040002C0 RID: 704
	public bool letterIsMultiplied;

	// Token: 0x040002C1 RID: 705
	public bool dialogueActive;

	// Token: 0x040002C2 RID: 706
	public bool dialogueEnded;

	// Token: 0x040002C3 RID: 707
	public bool outOfRange = true;

	// Token: 0x040002C4 RID: 708
	public AudioClip audioClip;

	// Token: 0x040002C5 RID: 709
	public AudioSource audioSource;
}
