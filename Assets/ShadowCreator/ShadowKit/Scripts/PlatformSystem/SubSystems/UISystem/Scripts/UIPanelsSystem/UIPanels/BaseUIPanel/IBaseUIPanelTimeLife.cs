using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IBaseUIPanelTimeLife {

    void OnEnter(object parameter = null);
    void OnPause(object parameter = null);
    void OnResume(object parameter = null);
    void OnExit(object parameter = null);
}
