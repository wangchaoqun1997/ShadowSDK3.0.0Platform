using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

class EmailTool {

    public static bool IsEmail(string str) {

        Regex re = new Regex(@"[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?");//实例化一个Regex对象

        if (re.IsMatch(str) == true) {
            Debug.Log("邮箱格式正确");//匹配则弹出”邮箱正确“
            return true;
        } else {
            Debug.Log("邮箱格式错误");//匹配则弹出”邮箱正确“
            return false;
        }

    }
}


