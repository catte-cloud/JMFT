using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200000C RID: 12
public class GlitchyScript : MonoBehaviour
{
    // Token: 0x06000025 RID: 37 RVA: 0x00002374 File Offset: 0x00000574
    private void Start()
    {
        this.itemSpriteDictionary = new Dictionary<int, Sprite>();
        this.AddStolenItemSprite(6, this.stealCD);
        this.AddStolenItemSprite(7, this.stealRadio);
        this.AddStolenItemSprite(12, this.stealHorn);
        this.agent = base.GetComponent<NavMeshAgent>();
        this.Wander();
    }

    // Token: 0x06000026 RID: 38 RVA: 0x000023C6 File Offset: 0x000005C6
    private void Update()
    {
        if (this.coolDown > 0f)
        {
            this.coolDown -= 1f * Time.deltaTime;
        }
    }

    // Token: 0x06000027 RID: 39 RVA: 0x000023F0 File Offset: 0x000005F0
    private void FixedUpdate()
    {
        Vector3 direction = this.player.position - base.transform.position;
        RaycastHit raycastHit;
        if ((Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player") && this.coolDown <= 0f && this.IsHoldingRequiredItem())
        {
            if (this.gc.item[0] == 6 || this.gc.item[0] == 7)
            {
                this.itemToSteal = 0;
            }
            else if (this.gc.item[1] == 6 || this.gc.item[1] == 7)
            {
                this.itemToSteal = 1;
            }
            else if (this.gc.item[2] == 6 || this.gc.item[2] == 7)
            {
                this.itemToSteal = 2;
            }
            this.db = true;
            this.TargetPlayer();
            this.agent.speed = 17f;
            return;
        }
        if (this.agent.velocity.magnitude <= 1f)
        {
            this.Wander();
        }
    }

    // Token: 0x06000028 RID: 40 RVA: 0x00002521 File Offset: 0x00000721
    public void AddStolenItemSprite(int itemID, Sprite sprite)
    {
        if (!this.itemSpriteDictionary.ContainsKey(itemID))
        {
            this.itemSpriteDictionary.Add(itemID, sprite);
            return;
        }
        this.itemSpriteDictionary[itemID] = sprite;
    }

    // Token: 0x06000029 RID: 41 RVA: 0x0000254C File Offset: 0x0000074C
    public Sprite GetItemValue(int itemID)
    {
        Sprite result = null;
        this.itemSpriteDictionary.TryGetValue(itemID, out result);
        return result;
    }

    // Token: 0x0600002A RID: 42 RVA: 0x0000256B File Offset: 0x0000076B
    private void Wander()
    {
        this.spriteRenderer.sprite = this.idle;
        this.wanderer.GetNewTarget();
        this.agent.SetDestination(this.wanderTarget.position);
    }

    // Token: 0x0600002B RID: 43 RVA: 0x000025A0 File Offset: 0x000007A0
    private void TargetPlayer()
    {
        this.agent.SetDestination(this.player.position);
        if (!this.hasPlayed)
        {
            this.hasPlayed = true;
            this.audioDevice.PlayOneShot(this.aud_YouShouldnt);
        }
    }

    // Token: 0x0600002C RID: 44 RVA: 0x000025DC File Offset: 0x000007DC
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.itemToSteal != -1)
        {
            gc.GetComponentInParent<TicketsScript>().RemoveTickets(20);
            this.spriteRenderer.sprite = this.GetItemValue(this.gc.item[this.itemToSteal]);
            this.coolDown = 0.5f;
            this.gc.LoseItem(this.itemToSteal);
            this.itemToSteal = -1;
            this.audioDevice.PlayOneShot(this.aud_Mine);
            this.hasPlayed = false;
        }
    }

    // Token: 0x0600002D RID: 45 RVA: 0x00002660 File Offset: 0x00000860
    private bool IsHoldingRequiredItem()
    {
        return this.gc.item[0] == 6 || this.gc.item[0] == 7 || this.gc.item[0] == 12 || this.gc.item[1] == 6 || this.gc.item[1] == 7 || this.gc.item[1] == 12 || this.gc.item[2] == 6 || this.gc.item[2] == 7 || this.gc.item[2] == 12;
    }

    // Token: 0x04000017 RID: 23
    public bool db;

    // Token: 0x04000018 RID: 24
    public bool hasPlayed;

    // Token: 0x04000019 RID: 25
    public Transform player;

    // Token: 0x0400001A RID: 26
    public Transform wanderTarget;

    // Token: 0x0400001B RID: 27
    public AILocationSelectorScript wanderer;

    // Token: 0x0400001C RID: 28
    public float coolDown;

    // Token: 0x0400001D RID: 29
    public NavMeshAgent agent;

    // Token: 0x0400001E RID: 30
    public GameControllerScript gc;

    // Token: 0x0400001F RID: 31
    public int itemToSteal;

    // Token: 0x04000020 RID: 32
    public SpriteRenderer spriteRenderer;

    // Token: 0x04000021 RID: 33
    public Sprite stealCD;

    // Token: 0x04000022 RID: 34
    public Sprite stealRadio;

    // Token: 0x04000023 RID: 35
    public Sprite stealHorn;

    // Token: 0x04000024 RID: 36
    public Sprite idle;

    // Token: 0x04000025 RID: 37
    public Dictionary<int, Sprite> itemSpriteDictionary;

    // Token: 0x04000026 RID: 38
    public AudioClip aud_YouShouldnt;

    // Token: 0x04000027 RID: 39
    public AudioClip aud_Mine;

    // Token: 0x04000028 RID: 40
    public AudioSource audioDevice;
}
