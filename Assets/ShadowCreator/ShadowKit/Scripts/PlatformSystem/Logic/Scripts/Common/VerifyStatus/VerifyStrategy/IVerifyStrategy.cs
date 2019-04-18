using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IVerifyStrategy {
    public abstract void OnUpdate(VerifyItemBase[] verifyItems);
}