﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public GameObject Pausemenu, PauseButton;

   public void Pause(){
       Time.timeScale = 0;
   }
   }
