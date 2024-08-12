using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IHasProgress 
{
    //事件的直接声明
    public event EventHandler<OnProgressChangerEventArgs> OnProGressChanged;
    public class OnProgressChangerEventArgs : EventArgs
    {
        public float progressNormalized;
    }
}
