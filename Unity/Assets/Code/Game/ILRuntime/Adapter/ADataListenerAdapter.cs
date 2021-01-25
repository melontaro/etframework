
using System;
using System.Collections;
using System.Collections.Generic;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

public class ADataListenerAdapter:CrossBindingAdaptor
{
public override Type BaseCLRType
{
    get
    {
        return typeof(BDFramework.DataListener.ADataListener);//这是你想继承的那个类
    }
}
public override Type AdaptorType
{
    get
    {
        return typeof(Adaptor);//这是实际的适配器类
    }
}
public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
{
    return new Adaptor(appdomain, instance);//创建一个新的实例
}
//实际的适配器类需要继承你想继承的那个类，并且实现CrossBindingAdaptorType接口
public class Adaptor : BDFramework.DataListener.ADataListener, CrossBindingAdaptorType
{
    ILTypeInstance instance;
    ILRuntime.Runtime.Enviorment.AppDomain appdomain;
    //缓存这个数组来避免调用时的GC Alloc
    object[] param1 = new object[1];
    public Adaptor()
    {

    }
    public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        this.appdomain = appdomain;
        this.instance = instance;
    }
    public ILTypeInstance ILInstance { get { return instance; } }
bool m_bSetDataGot = false;
IMethod m_SetData = null;
public  void SetData (System.String arg0,System.Object arg1,System.Boolean arg2)
{
   if(!m_bSetDataGot)
   {
       m_SetData = instance.Type.GetMethod("SetData",3);
       m_bSetDataGot = true;
   }
          if(m_SetData != null)
       {
            appdomain.Invoke(m_SetData, instance,arg0,arg1,arg2);
        }
       else
       {
           
       } 
}
bool m_bTriggerEventGot = false;
IMethod m_TriggerEvent = null;
public  void TriggerEvent (System.String arg0,System.Object arg1,System.Boolean arg2)
{
   if(!m_bTriggerEventGot)
   {
       m_TriggerEvent = instance.Type.GetMethod("TriggerEvent",3);
       m_bTriggerEventGot = true;
   }
          if(m_TriggerEvent != null)
       {
            appdomain.Invoke(m_TriggerEvent, instance,arg0,arg1,arg2);
        }
       else
       {
           
       } 
}
bool m_bGetDataGot = false;
IMethod m_GetData = null;
public   GetData (System.String arg0)
{
   if(!m_bGetDataGot)
   {
       m_GetData = instance.Type.GetMethod("GetData",1);
       m_bGetDataGot = true;
   }
          if(m_GetData != null)
       {
           return() appdomain.Invoke(m_GetData, instance,arg0);
        }
       else
       {
           return null;
       } 
}
bool m_bAddListenerGot = false;
IMethod m_AddListener = null;
public  void AddListener (System.String arg0, arg1,System.Int32 arg2,System.Int32 arg3,System.Boolean arg4)
{
   if(!m_bAddListenerGot)
   {
       m_AddListener = instance.Type.GetMethod("AddListener",5);
       m_bAddListenerGot = true;
   }
          if(m_AddListener != null)
       {
            appdomain.Invoke(m_AddListener, instance,arg0,arg1,arg2,arg3,arg4);
        }
       else
       {
           
       } 
}
bool m_bClearListenerGot = false;
IMethod m_ClearListener = null;
public  void ClearListener (System.String arg0)
{
   if(!m_bClearListenerGot)
   {
       m_ClearListener = instance.Type.GetMethod("ClearListener",1);
       m_bClearListenerGot = true;
   }
          if(m_ClearListener != null)
       {
            appdomain.Invoke(m_ClearListener, instance,arg0);
        }
       else
       {
           
       } 
}
bool m_bRemoveListenerGot = false;
IMethod m_RemoveListener = null;
public  void RemoveListener (System.String arg0, arg1)
{
   if(!m_bRemoveListenerGot)
   {
       m_RemoveListener = instance.Type.GetMethod("RemoveListener",2);
       m_bRemoveListenerGot = true;
   }
          if(m_RemoveListener != null)
       {
            appdomain.Invoke(m_RemoveListener, instance,arg0,arg1);
        }
       else
       {
           
       } 
}
bool m_bRemoveListenerGot = false;
IMethod m_RemoveListener = null;
public  void RemoveListener (System.String arg0)
{
   if(!m_bRemoveListenerGot)
   {
       m_RemoveListener = instance.Type.GetMethod("RemoveListener",1);
       m_bRemoveListenerGot = true;
   }
          if(m_RemoveListener != null)
       {
            appdomain.Invoke(m_RemoveListener, instance,arg0);
        }
       else
       {
           
       } 
}
}
}