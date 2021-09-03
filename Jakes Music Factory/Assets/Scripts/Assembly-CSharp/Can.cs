using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class Can : MonoBehaviour
{
    // Token: 0x0600000C RID: 12 RVA: 0x00002164 File Offset: 0x00000364
    private void Start()
    {
        UnityEngine.Object.Destroy(base.gameObject, 5f);
    }

    // Token: 0x0600000D RID: 13 RVA: 0x00002178 File Offset: 0x00000378
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            base.GetComponentInParent<TicketsScript>().RemoveTickets(10);
            other.transform.position -= base.transform.forward * 3f;
            float stunTime = UnityEngine.Random.Range(5f, 10f);
            other.GetComponent<PlayerScript>().StunPlayer(stunTime);
            this.yeet.Wander();
            this.yeet.sprite.sprite = this.yeet.attack;
        }
    }

    // Token: 0x0600000E RID: 14 RVA: 0x000021FF File Offset: 0x000003FF
    private void FixedUpdate()
    {
        this.rb.velocity = base.transform.forward * this.canSpeed;
    }

    // Token: 0x04000008 RID: 8
    public YeetScript yeet;

    // Token: 0x04000009 RID: 9
    public Rigidbody rb;

    // Token: 0x0400000A RID: 10
    private float canSpeed = 20f;
}
