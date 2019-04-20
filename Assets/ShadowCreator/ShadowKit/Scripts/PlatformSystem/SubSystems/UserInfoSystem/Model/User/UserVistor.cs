using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UserVistor :UserBase{

    public UserVistor() : base(UserType.Vistor) {
        
    }

    public override void Init() {
        Nickname = "游客";
    }
    
}