using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IHasProgress 
{
    //�¼���ֱ������
    public event EventHandler<OnProgressChangerEventArgs> OnProGressChanged;
    public class OnProgressChangerEventArgs : EventArgs
    {
        public float progressNormalized;
    }
}
