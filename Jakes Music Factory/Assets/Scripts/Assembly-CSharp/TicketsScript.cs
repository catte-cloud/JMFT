using System.Net.Mime; //???? the fuck
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketsScript : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.GetInt("Tickets", LastAmount);
    }
    public void AddTickets(int Add)
    {
        TicketsAMT = Add;
        AddedTickets += TicketsAMT + PlayerPrefs.GetInt("Tickets", LastAmount);
        LastAmount += PlayerPrefs.GetInt("Tickets");
        PlayerPrefs.SetInt("Tickets", PlayerPrefs.GetInt("Tickets") + Add);
        //PlayerPrefs.SetInt("Tickets", LastAmount);
        StartCoroutine("Add");
    }
    public void RemoveTickets(int Remove)
    {
        TicketsAMT = Remove;
        AddedTickets -= TicketsAMT + PlayerPrefs.GetInt("Tickets", LastAmount);
        LastAmount -= PlayerPrefs.GetInt("Tickets");
        PlayerPrefs.SetInt("Tickets", PlayerPrefs.GetInt("Tickets") - Remove);
        //PlayerPrefs.SetInt("Tickets", LastAmount);
        StartCoroutine("Subtract");
    }
    public IEnumerator Add()
    {
        Adding.text = TicketsAMT.ToString();
        Added.text = AddedTickets.ToString();
        LastAMT.text = LastAmount.ToString();
        __Anim.SetTrigger("Add");
        yield return new WaitForSeconds(50);
        __Anim.ResetTrigger("Add");
        /*
            i am retarded.
        */
    }
    public IEnumerator Subtract()
    {
        Adding.text = TicketsAMT.ToString();
        Added.text = AddedTickets.ToString();
        LastAMT.text = LastAmount.ToString();
        __Anim.SetTrigger("Subtract");
        yield return new WaitForSeconds(50);
        __Anim.ResetTrigger("Subtract");
        /*
        
        */
    }
    public int TicketsAMT;
    public int AddedTickets;
    public int LastAmount;
    public Text Added, Adding, LastAMT;
    public Animator __Anim;
}
