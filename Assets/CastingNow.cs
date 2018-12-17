using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingNow : MonoBehaviour
{

    public CardUI viz;

    // Update is called once per frame
    void Update()
    {
        viz.SetCard(CardPlayer.instance.PlayingNow);
        viz.gameObject.SetActive(CardPlayer.instance.PlayingNow != null);
    }
}
