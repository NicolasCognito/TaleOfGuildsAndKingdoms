using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventGenerator
{
    //interface for EventGenerator should make sure that both execute and condition are implemented
    bool Condition(params object[] args);

    void Execute(params object[] args);

}
