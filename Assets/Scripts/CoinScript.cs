﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.gameObject.tag == "Player"){ 
           CoinCounter.coinAmount += 1;
            Destroy(gameObject);
             SoundManagerScript.playSoundCoin();
       }
   }
}
